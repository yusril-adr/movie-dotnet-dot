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
        var movie1 = new Movie
        {
            Id = 9981, // Get from TMDB API
            Title = "Avengers: Age of Ultron",
            Overview = "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.",
            Poster = "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg"
        };

        var movie2 = new Movie
        {
            Id = 24428, // Get from TMDB API
            Title = "The Avengers",
            Overview = "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!",
            Poster = "https://image.tmdb.org/t/p/original/RYMX2wcKCBAr24UyPD7xwmjaTn.jpg",
        };
        
        modelBuilder.Entity<Movie>().HasData(
            movie1,
            movie2
        );

        modelBuilder.Entity<MovieTags>().HasData(
            new MovieTags {
                Id = 1,
                MovieId = movie1.Id,
                TagId = tag.Id
            }
        );

        var studio1 = new Studio {
            Id = 1,
            StudioNumber = 1,
            SeatCapacity = 50,
        };

        var studio2 = new Studio {
            Id = 2,
            StudioNumber = 2,
            SeatCapacity = 50,
        };

        modelBuilder.Entity<Studio>().HasData([
            studio1,
            studio2,
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

        var movieSchedule1 = new MovieSchedule {
            Id = 1,
            MovieId = movie1.Id,
            StudioId = studio1.Id,
            StartTime = "15:00",
            EndTime = "17:00",
            RemainingSeat = studio1.SeatCapacity - 3,
            Date = DateOnly.FromDateTime(DateTime.Now),
            Price = 15000,
        };
        var movieSchedule2 = new MovieSchedule {
            Id = 3,
            MovieId = movie2.Id,
            StudioId = studio1.Id,
            StartTime = "08:00",
            EndTime = "10:00",
            RemainingSeat = studio1.SeatCapacity - 1,
            Date = DateOnly.FromDateTime(DateTime.Now),
            Price = 15000,
        };
        modelBuilder.Entity<MovieSchedule>().HasData([
            movieSchedule1,
            new MovieSchedule {
                Id = 2,
                MovieId = movie1.Id,
                StudioId = studio2.Id,
                StartTime = "15:10",
                EndTime = "17:10",
                RemainingSeat = studio2.SeatCapacity,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Price = 15000,
            },
            movieSchedule2,
            new MovieSchedule {
                Id = 4,
                MovieId = movie2.Id,
                StudioId = studio2.Id,
                StartTime = "08:30",
                EndTime = "10:30",
                RemainingSeat = studio2.SeatCapacity,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Price = 15000,
            },
        ]);

        var order1 = new Order {
            Id = 1,
            UserId = 1,
            TotalItemPrice = 60000,
        };

        modelBuilder.Entity<Order>().HasData([
            order1,
        ]);

        OrderItems[] orderItems = [
            new OrderItems{
                Id = 1,
                OrderId = order1.Id,
                MovieScheduleId = movieSchedule1.Id,
                Qty = 3,
                SubTotalPrice = movieSchedule1.Price * 3
            },
            new OrderItems{
                Id = 2,
                OrderId = order1.Id,
                MovieScheduleId = movieSchedule2.Id,
                Qty = 1,
                SubTotalPrice = movieSchedule2.Price * 1
            }
        ];

        modelBuilder.Entity<OrderItems>().HasData(orderItems);
    }


    public DbSet<User> User { get; set; } = null!;
    public DbSet<Movie> Movie { get; set; } = null!;
    public DbSet<Tag> Tag { get; set; } = null!;
    public DbSet<MovieTags> MovieTags { get; set; } = null!;
    public DbSet<Studio> Studio { get; set; } = null!;
    public DbSet<MovieSchedule> MovieSchedule { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<OrderItems> OrderItems { get; set; } = null!;
}