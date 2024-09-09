using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Helpers;
using RestSharp;

namespace dot_dotnet_test_api.Contexts;

public class SQLServerContext : DbContext
{
    public SQLServerContext(DbContextOptions<SQLServerContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seeding User Master Data using HasData method
        modelBuilder.Entity<UserV1>().HasData(
           new UserV1
           {
               Id = 1,
               Name = "user test",
               Email = "user@getnada.com",
               Password = PasswordHasher.HashPassword("Rahasia123"),
               Avatar = Path.Combine("./files/images/avatar", "example.png"),
           }
       );

        //Seeding State Master Data using HasData method
        modelBuilder.Entity<MovieV1>().HasData(
            new MovieV1
            {
                Id = 1,
                TmdbId = 9981,
                Title = "Avengers: Age of Ultron",
                Overview = "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.",
                Poster = "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg",
            }
        );
    }


    public DbSet<TodoItemV1> TodoItems { get; set; } = null!;
    public DbSet<UserV1> Users { get; set; } = null!;
    public DbSet<MovieV1> Movies { get; set; } = null!;
}