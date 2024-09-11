using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableMovieScheduleAndStudio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studio_number = table.Column<int>(type: "int", nullable: false),
                    seat_capacity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Schedules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movie_id = table.Column<long>(type: "bigint", nullable: true),
                    studio_id = table.Column<long>(type: "bigint", nullable: true),
                    start_time = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    end_time = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movie_Schedules_Movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Movie_Schedules_Studios_studio_id",
                        column: x => x.studio_id,
                        principalTable: "Studios",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9580), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9580), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9580) });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "id", "created_at", "deleted_at", "seat_capacity", "studio_number", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9630), null, 50, 1, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9630) },
                    { 2L, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640), null, 50, 2, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640) },
                    { 3L, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640), null, 50, 3, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640) },
                    { 4L, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640), null, 50, 4, new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640) }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9490), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9560), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9570), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 669, DateTimeKind.Local).AddTicks(1450), "6fxwkvuLjZAfs6NHLlpZWM8+R/4K+ajfAe2jL6JQ+c6B+mdSHvPKsQiygJaPve9A", new DateTime(2024, 9, 11, 10, 15, 21, 669, DateTimeKind.Local).AddTicks(1490) });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Schedules_movie_id",
                table: "Movie_Schedules",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Schedules_studio_id",
                table: "Movie_Schedules",
                column: "studio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Schedules");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1150), new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1150), new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1090), new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1130), new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1140), new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 8, 6, 7, 217, DateTimeKind.Local).AddTicks(7940), "9+2y7gb8BRn91FPWXJ5iculKdqFPOxBP0AKUsfSiogFMyqr+CwKkO6TcVRbStFJY", new DateTime(2024, 9, 11, 8, 6, 7, 217, DateTimeKind.Local).AddTicks(7980) });
        }
    }
}
