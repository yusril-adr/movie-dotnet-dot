using dot_dotnet_test_api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Middlewares;
using dot_dotnet_test_api.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define the OAuth2.0 scheme that's in use (i.e., Implicit Flow)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });

});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddDbContext<SQLServerContext>(opt =>
    opt.UseSqlServer(connectionString));

builder.Services.AddTransient<ErrorHandlingMiddleware>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AddNowPlayingMovieJob>();

builder.Services.AddQuartz(q =>
{
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("AddNowPlayingMovieJob");
    q.AddJob<AddNowPlayingMovieJob>(opts => opts
        .WithIdentity(jobKey)
        .UsingJobData("apikey", builder.Configuration["TMDB:key"])
    );
    
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithCronSchedule("0 0 0 * * ?") // At 00.00 AM
        // .StartNow()
        // .WithSimpleSchedule(x => x
        //     .WithIntervalInSeconds(120)
        //     .RepeatForever()
        // )
    );
});
builder.Services.AddQuartzServer(q => q.WaitForJobsToComplete = true);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "files/images"));
var requestPath = "/images";

// Enable displaying browser links.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(
//         Path.Combine(builder.Environment.ContentRootPath, "files/images/avatar")),
//     RequestPath = "/images/avatar"
// });


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();

using var scope = app.Services.CreateScope();

StdSchedulerFactory factory = new StdSchedulerFactory();
IScheduler scheduler = await factory.GetScheduler();

IJobDetail job = JobBuilder.Create<AddNowPlayingMovieJob>()
 .WithIdentity("AddNowPlayingMovieJob", "movies") // name "AddNowPlayingMovieJob", group "movies"
 .UsingJobData("apikey", builder.Configuration["TMDB:key"])
 .Build();

Console.WriteLine(DateTime.Now);
ITrigger trigger = TriggerBuilder.Create()
  .WithIdentity("AddNowPlayingMovieJob", "movies")
  .WithCronSchedule("0 0 0 * * ?") // At 00.00 AM
  .StartNow()
  .WithSimpleSchedule(x => x
    .WithIntervalInSeconds(1)
    .RepeatForever()
  )
  .ForJob(job)
  .Build();

await scheduler.ScheduleJob(job, trigger);
await scheduler.Start();