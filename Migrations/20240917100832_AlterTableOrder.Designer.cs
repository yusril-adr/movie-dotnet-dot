﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dot_dotnet_test_api.Contexts;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20240917100832_AlterTableOrder")]
    partial class AlterTableOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dot_dotnet_test_api.Models.Movie", b =>
                {
                    b.Property<long?>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)")
                        .HasColumnName("overview");

                    b.Property<DateTime?>("PlayUntil")
                        .HasColumnType("datetime2")
                        .HasColumnName("play_until");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("poster");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("movies");

                    b.HasData(
                        new
                        {
                            Id = 9981L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160),
                            Overview = "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.",
                            PlayUntil = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160),
                            Poster = "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg",
                            Title = "Avengers: Age of Ultron",
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160)
                        },
                        new
                        {
                            Id = 24428L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160),
                            Overview = "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!",
                            PlayUntil = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160),
                            Poster = "https://image.tmdb.org/t/p/original/RYMX2wcKCBAr24UyPD7xwmjaTn.jpg",
                            Title = "The Avengers",
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7170)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.MovieSchedule", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("end_time");

                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint")
                        .HasColumnName("movie_id");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<int?>("RemainingSeat")
                        .HasColumnType("int")
                        .HasColumnName("remaining_Seat");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("start_time");

                    b.Property<long?>("StudioId")
                        .HasColumnType("bigint")
                        .HasColumnName("studio_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("StudioId");

                    b.ToTable("movie_schedules");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7260),
                            Date = new DateOnly(2024, 9, 17),
                            EndTime = "17:00",
                            MovieId = 9981L,
                            Price = 15000,
                            RemainingSeat = 50,
                            StartTime = "15:00",
                            StudioId = 1L,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7260)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7290),
                            Date = new DateOnly(2024, 9, 17),
                            EndTime = "17:10",
                            MovieId = 9981L,
                            Price = 15000,
                            RemainingSeat = 50,
                            StartTime = "15:10",
                            StudioId = 2L,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7290)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7270),
                            Date = new DateOnly(2024, 9, 17),
                            EndTime = "10:00",
                            MovieId = 24428L,
                            Price = 15000,
                            RemainingSeat = 50,
                            StartTime = "08:00",
                            StudioId = 1L,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7270)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7300),
                            Date = new DateOnly(2024, 9, 17),
                            EndTime = "10:30",
                            MovieId = 24428L,
                            Price = 15000,
                            RemainingSeat = 50,
                            StartTime = "08:30",
                            StudioId = 2L,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7300)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.MovieTags", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<long?>("MovieId")
                        .HasColumnType("bigint")
                        .HasColumnName("movie_id");

                    b.Property<long?>("TagId")
                        .HasColumnType("bigint")
                        .HasColumnName("tag_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("TagId");

                    b.ToTable("movie_tags");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7210),
                            MovieId = 9981L,
                            TagId = 1L,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7210)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Order", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("TotalItemPrice")
                        .HasColumnType("int")
                        .HasColumnName("total_item_price");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7310),
                            TotalItemPrice = 60000,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7310),
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.OrderItems", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<long?>("MovieScheduleId")
                        .HasColumnType("bigint")
                        .HasColumnName("movie_schedule_id");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<int?>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<int?>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.Property<int?>("SubTotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("sub_total_price");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("MovieScheduleId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7330),
                            MovieScheduleId = 1L,
                            OrderId = 1L,
                            Qty = 3,
                            SubTotalPrice = 45000,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7330)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7340),
                            MovieScheduleId = 3L,
                            OrderId = 1L,
                            Qty = 1,
                            SubTotalPrice = 15000,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7340)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Studio", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<int>("SeatCapacity")
                        .HasColumnType("int")
                        .HasColumnName("seat_capacity");

                    b.Property<int>("StudioNumber")
                        .HasColumnType("int")
                        .HasColumnName("studio_number");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("studios");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7220),
                            SeatCapacity = 50,
                            StudioNumber = 1,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7220)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7230),
                            SeatCapacity = 50,
                            StudioNumber = 2,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7230)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7240),
                            SeatCapacity = 50,
                            StudioNumber = 3,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7240)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7250),
                            SeatCapacity = 50,
                            StudioNumber = 4,
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7250)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Tag", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("tags");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7090),
                            Name = "Action",
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7100)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140),
                            Name = "Comedy",
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140),
                            Name = "Fantasy",
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<bool>("Is_admin")
                        .HasColumnType("bit")
                        .HasColumnName("is_admin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Avatar = "./files/images/avatar/example.png",
                            CreatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 173, DateTimeKind.Local).AddTicks(8760),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@getnada.com",
                            Is_admin = false,
                            Name = "user test",
                            Password = "hJ/YEEHqSaSEx6+hEn1c5XdO3siizSMdTbzI1jwTtTZbkAmHhbKytJB1rn+ERZ+p",
                            UpdatedAt = new DateTime(2024, 9, 17, 17, 8, 32, 173, DateTimeKind.Local).AddTicks(8770)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.MovieSchedule", b =>
                {
                    b.HasOne("dot_dotnet_test_api.Models.Movie", "Movie")
                        .WithMany("MovieSchedules")
                        .HasForeignKey("MovieId");

                    b.HasOne("dot_dotnet_test_api.Models.Studio", "Studio")
                        .WithMany()
                        .HasForeignKey("StudioId");

                    b.Navigation("Movie");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.MovieTags", b =>
                {
                    b.HasOne("dot_dotnet_test_api.Models.Movie", "Movie")
                        .WithMany("MovieTags")
                        .HasForeignKey("MovieId");

                    b.HasOne("dot_dotnet_test_api.Models.Tag", "Tag")
                        .WithMany("MovieTag")
                        .HasForeignKey("TagId");

                    b.Navigation("Movie");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Order", b =>
                {
                    b.HasOne("dot_dotnet_test_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.OrderItems", b =>
                {
                    b.HasOne("dot_dotnet_test_api.Models.MovieSchedule", "MovieSchedule")
                        .WithMany()
                        .HasForeignKey("MovieScheduleId");

                    b.HasOne("dot_dotnet_test_api.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("MovieSchedule");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Movie", b =>
                {
                    b.Navigation("MovieSchedules");

                    b.Navigation("MovieTags");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.Tag", b =>
                {
                    b.Navigation("MovieTag");
                });
#pragma warning restore 612, 618
        }
    }
}
