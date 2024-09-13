using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableNameMovieAndSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Schedules_Movies_movie_id",
                table: "Movie_Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Schedules_studios_studio_id",
                table: "Movie_Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Tags_Movies_movie_id",
                table: "Movie_Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Tags_Tags_tag_id",
                table: "Movie_Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_Movie_Schedules_movie_schedule_id",
                table: "order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Tags",
                table: "Movie_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Schedules",
                table: "Movie_Schedules");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "tags");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "Movie_Tags",
                newName: "movie_tags");

            migrationBuilder.RenameTable(
                name: "Movie_Schedules",
                newName: "movie_schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Tags_tag_id",
                table: "movie_tags",
                newName: "IX_movie_tags_tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Tags_movie_id",
                table: "movie_tags",
                newName: "IX_movie_tags_movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Schedules_studio_id",
                table: "movie_schedules",
                newName: "IX_movie_schedules_studio_id");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Schedules_movie_id",
                table: "movie_schedules",
                newName: "IX_movie_schedules_movie_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "play_until",
                table: "movies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tags",
                table: "tags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_tags",
                table: "movie_tags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_schedules",
                table: "movie_schedules",
                column: "id");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7430), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7430), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7480), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7490), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7490), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7500), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7500) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7370), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7410), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7420), new DateTime(2024, 9, 13, 16, 23, 33, 1, DateTimeKind.Local).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 16, 23, 32, 991, DateTimeKind.Local).AddTicks(9140), "WfTARYfPaGkxiuUSOEjpwt3SmGzib72HHccyfhAp1IbkCGwDsuRyQ/RXLCxeYvXS", new DateTime(2024, 9, 13, 16, 23, 32, 991, DateTimeKind.Local).AddTicks(9180) });

            migrationBuilder.AddForeignKey(
                name: "FK_movie_schedules_movies_movie_id",
                table: "movie_schedules",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_schedules_studios_studio_id",
                table: "movie_schedules",
                column: "studio_id",
                principalTable: "studios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_tags_movies_movie_id",
                table: "movie_tags",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_tags_tags_tag_id",
                table: "movie_tags",
                column: "tag_id",
                principalTable: "tags",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_movie_schedules_movie_schedule_id",
                table: "order_items",
                column: "movie_schedule_id",
                principalTable: "movie_schedules",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_schedules_movies_movie_id",
                table: "movie_schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_schedules_studios_studio_id",
                table: "movie_schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_tags_movies_movie_id",
                table: "movie_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_movie_tags_tags_tag_id",
                table: "movie_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_movie_schedules_movie_schedule_id",
                table: "order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tags",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_tags",
                table: "movie_tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_schedules",
                table: "movie_schedules");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "movie_tags",
                newName: "Movie_Tags");

            migrationBuilder.RenameTable(
                name: "movie_schedules",
                newName: "Movie_Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_movie_tags_tag_id",
                table: "Movie_Tags",
                newName: "IX_Movie_Tags_tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_movie_tags_movie_id",
                table: "Movie_Tags",
                newName: "IX_Movie_Tags_movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_movie_schedules_studio_id",
                table: "Movie_Schedules",
                newName: "IX_Movie_Schedules_studio_id");

            migrationBuilder.RenameIndex(
                name: "IX_movie_schedules_movie_id",
                table: "Movie_Schedules",
                newName: "IX_Movie_Schedules_movie_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "play_until",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Tags",
                table: "Movie_Tags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Schedules",
                table: "Movie_Schedules",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2440), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2430), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2380), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2380) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2420), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2420), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2480), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2490), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2490), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2500), new DateTime(2024, 9, 13, 10, 2, 34, 381, DateTimeKind.Local).AddTicks(2500) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 10, 2, 34, 371, DateTimeKind.Local).AddTicks(2450), "Ff3b8dXuQGi4w5XY0glXb2i82Ghxrc6KwyPZ4/YoM9pO7hWV/2m+IZZol1BKGaTR", new DateTime(2024, 9, 13, 10, 2, 34, 371, DateTimeKind.Local).AddTicks(2520) });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Schedules_Movies_movie_id",
                table: "Movie_Schedules",
                column: "movie_id",
                principalTable: "Movies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Schedules_studios_studio_id",
                table: "Movie_Schedules",
                column: "studio_id",
                principalTable: "studios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Tags_Movies_movie_id",
                table: "Movie_Tags",
                column: "movie_id",
                principalTable: "Movies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Tags_Tags_tag_id",
                table: "Movie_Tags",
                column: "tag_id",
                principalTable: "Tags",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_Movie_Schedules_movie_schedule_id",
                table: "order_items",
                column: "movie_schedule_id",
                principalTable: "Movie_Schedules",
                principalColumn: "id");
        }
    }
}
