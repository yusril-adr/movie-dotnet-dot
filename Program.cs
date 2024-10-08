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
using Quartz.AspNetCore;
using Coravel;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.API.Version1.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection");

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
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
        options.Events = new JwtBearerEvents
        {
            OnChallenge = (context) =>
            {
                Console.WriteLine("Im here");
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = (context) =>
            {
                // TODO: Trying to implement custom 401 without jwt
                // var unAuthorizedresponse = new Response<object>(
                //     data: null,
                //     errors: ["Unauthorized"],
                //     message: "Unauthorized"
                // );
                // context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                // await context.Response.WriteAsJsonAsync(
                //     unAuthorizedresponse
                // );
                context.HttpContext.Response.Redirect("/login");
                Console.WriteLine("Im here");
                return Task.CompletedTask;
            }
        };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddDbContext<SQLServerContext>(opt =>
    opt.UseSqlServer(connectionString));

builder.Services.AddSingleton<TokenHelper>();
builder.Services.AddSingleton<FileHelper>();

builder.Services.AddTransient<ErrorHandlingMiddleware>();
builder.Services.AddTransient<EmailInvocable>();

builder.Services.AddScoped<AddNowPlayingMovieJob>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<MovieRepository>();
builder.Services.AddScoped<MovieService>();

builder.Services.AddScoped<MovieScheduleRepository>();
builder.Services.AddScoped<MovieScheduleService>();

builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<TagService>();

builder.Services.AddScoped<StudioRepository>();
builder.Services.AddScoped<StudioService>();

builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("AddNowPlayingMovieJob");
    q.AddJob<AddNowPlayingMovieJob>(opts => opts
        .WithIdentity(jobKey)
        .UsingJobData("apikey", builder.Configuration["TMDB:key"])
    );
    
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        // TODO alternative rule
        // .WithCronSchedule("0 0 0 * * ?") // At 00.00 AM
        .StartNow()
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(120)
            .RepeatForever()
        )
    );
});
builder.Services.AddQuartzServer(q => q.WaitForJobsToComplete = true);

builder.Services.AddQueue();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
