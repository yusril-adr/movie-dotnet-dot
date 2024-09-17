using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMovieTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "date", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1780), new DateOnly(2024, 9, 17), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "date", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1790), new DateOnly(2024, 9, 17), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.InsertData(
                table: "movie_tags",
                columns: new[] { "id", "created_at", "deleted_at", "movie_id", "tag_id", "updated_at" },
                values: new object[] { 1L, new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1710), null, 9981L, 1L, new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1660), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1650), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1730), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1730), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1750), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1750), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1590), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1640) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1640) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 207, DateTimeKind.Local).AddTicks(3110), "gkK/XKYIrF8dLB4aLofwWgA9Xt3HTOiL+eW2mbAJJ/o37msHrLp9gQos+mH1YWL4", new DateTime(2024, 9, 17, 16, 38, 45, 207, DateTimeKind.Local).AddTicks(3120) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movie_tags",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "date", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5700), new DateOnly(1, 1, 1), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "date", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5710), new DateOnly(1, 1, 1), new DateTime(2024, 9, 17, 16, 30, 25, 28, DateTimeKind.Local).AddTicks(5710) });

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
    }
}
