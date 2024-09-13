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

        // modelBuilder.Entity<MovieV1>()
        // .HasMany(e => e.Tags)
        // .WithMany(e => e.Movies)
        // .UsingEntity(
        //     "Movies_Tag",
        //     l => l.HasOne(typeof(TagV1)).WithMany().HasForeignKey("TagId").HasPrincipalKey(nameof(TagV1.Id)),
        //     r => r.HasOne(typeof(MovieV1)).WithMany().HasForeignKey("MovieId").HasPrincipalKey(nameof(MovieV1.Id)),
        //     j => j.HasKey("MovieId", "TagId")
        // );

        // modelBuilder.Entity<MovieV1>()
        // .HasMany(e => e.Tags)
        // .WithMany(e => e.Movies)
        // .UsingEntity(
        //     "Movies_Tags"
            // l => l.HasOne<TagV1>().WithMany().HasForeignKey(e => e.TagId),
            // r => r.HasOne<MovieV1>().WithMany().HasForeignKey(e => e.MovieId)
            // j => j.HasKey("movie_id", "tag_id")
        // );

        var tag = new TagV1
        {
            Id = 1,
            Name = "Action",
        };

        modelBuilder.Entity<TagV1>().HasData([
            tag,
            new TagV1
            {
                Id = 2,
                Name = "Comedy",
            },
            new TagV1
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

        modelBuilder.Entity<StudioV1>().HasData([
            new StudioV1 {
                Id = 1,
                StudioNumber = 1,
                SeatCapacity = 50,
            },
            new StudioV1 {
                Id = 2,
                StudioNumber = 2,
                SeatCapacity = 50,
            },
            new StudioV1 {
                Id = 3,
                StudioNumber = 3,
                SeatCapacity = 50,
            },
            new StudioV1 {
                Id = 4,
                StudioNumber = 4,
                SeatCapacity = 50,
            }
        ]);
    }


    public DbSet<User> Users { get; set; } = null!;
    public DbSet<MovieV1> Movies { get; set; } = null!;
    public DbSet<TagV1> Tags { get; set; } = null!;
    public DbSet<MovieTagsV1> MovieTags { get; set; } = null!;
    public DbSet<StudioV1> Studio { get; set; } = null!;
    public DbSet<MovieScheduleV1> Schedule { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<OrderItems> OrderItems { get; set; } = null!;
}