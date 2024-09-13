using Microsoft.EntityFrameworkCore;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Helpers;
using NuGet.Protocol;

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
        modelBuilder.Entity<User>().HasData(
           new User
           {
               Id = 1,
               Name = "user test",
               Email = "user@getnada.com",
               Password = PasswordHasher.HashPassword("Rahasia123"),
               Avatar = Path.Combine("./files/images/avatar", "example.png"),
           }
       );

        var tag = new Tag
        {
            Id = 1,
            Name = "Action",
        };

        modelBuilder.Entity<Tag>().HasData([
            tag,
            new Tag
            {
                Id = 2,
                Name = "Comedy",
            },
            new Tag
            {
                Id = 3,
                Name = "Fantasy",
            }
        ]);

        //Seeding State Master Data using HasData method
        var movie = new MovieV1
        {
            Id = 9981, // Get from TMDB API
            Title = "Avengers: Age of Ultron",
            Overview = "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.",
            Poster = "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg",
            MovieTags = [],
        };
        
        modelBuilder.Entity<MovieV1>().HasData(
            movie
        );

        modelBuilder.Entity<Studio>().HasData([
            new Studio {
                Id = 1,
                StudioNumber = 1,
                SeatCapacity = 50,
            },
            new Studio {
                Id = 2,
                StudioNumber = 2,
                SeatCapacity = 50,
            },
            new Studio {
                Id = 3,
                StudioNumber = 3,
                SeatCapacity = 50,
            },
            new Studio {
                Id = 4,
                StudioNumber = 4,
                SeatCapacity = 50,
            }
        ]);
    }


    public DbSet<User> User { get; set; } = null!;
    public DbSet<MovieV1> Movies { get; set; } = null!;
    public DbSet<Tag> Tag { get; set; } = null!;
    public DbSet<MovieTags> MovieTags { get; set; } = null!;
    public DbSet<Studio> Studio { get; set; } = null!;
    public DbSet<MovieScheduleV1> MovieSchedule { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<OrderItems> OrderItems { get; set; } = null!;
}