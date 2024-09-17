using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMovieSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "movie_schedules",
                columns: new[] { "id", "created_at", "date", "deleted_at", "end_time", "movie_id", "price", "remaining_Seat", "start_time", "studio_id", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5700), new DateOnly(1, 1, 1), null, "17:00", 9981L, 15000, 50, "15:00", 1L, new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5700) },
                    { 2L, new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5710), new DateOnly(1, 1, 1), null, "17:10", 9981L, 15000, 50, "15:10", 2L, new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5710) }
                });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5580), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5580), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5640), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5650), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5670), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5670), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5510), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5560), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5570), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 18, DateTimeKind.Local).AddTicks(4550), "9sUfeIqtk3uw/R6BYXBz346icTkUnBhGo3hxZOpj7kC+4Itebiw8V80o65A/+cuI", new DateTime(2024, 9, 17, 16, 30, 25, 18, DateTimeKind.Local).AddTicks(4590) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 2L);

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
        }
    }
}
