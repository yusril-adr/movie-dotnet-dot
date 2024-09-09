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
    [Migration("20240909034308_CreateTableMovie")]
    partial class CreateTableMovie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dot_dotnet_test_api.Models.MovieV1", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("overview");

                    b.Property<DateTime>("PlayUntil")
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

                    b.Property<int>("TmdbId")
                        .HasColumnType("int")
                        .HasColumnName("tmdb_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 9, 9, 10, 43, 7, 494, DateTimeKind.Local).AddTicks(7380),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overview = "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.",
                            PlayUntil = new DateTime(2024, 9, 9, 10, 43, 7, 494, DateTimeKind.Local).AddTicks(7380),
                            Poster = "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg",
                            Title = "Avengers: Age of Ultron",
                            TmdbId = 9981,
                            UpdatedAt = new DateTime(2024, 9, 9, 10, 43, 7, 494, DateTimeKind.Local).AddTicks(7380)
                        });
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.TodoItemV1", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit")
                        .HasColumnName("is_complete");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("dot_dotnet_test_api.Models.UserV1", b =>
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

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Avatar = "./files/images/avatar/example.png",
                            CreatedAt = new DateTime(2024, 9, 9, 10, 43, 7, 485, DateTimeKind.Local).AddTicks(990),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@getnada.com",
                            Is_admin = false,
                            Name = "user test",
                            Password = "fLXd0lWmCyjBU4Qfc3BaXOq7ASGgrTg4fpeTeXldXoUntGnQToy2VhxIwfvfup4F",
                            UpdatedAt = new DateTime(2024, 9, 9, 10, 43, 7, 485, DateTimeKind.Local).AddTicks(1020)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
