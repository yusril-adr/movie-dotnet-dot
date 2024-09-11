using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMovieAddScheduleVirtualColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8610), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8610), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8610) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8660), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8660), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8660), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8670), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8540), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8540) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 9, 11, 13, 56, 41, 500, DateTimeKind.Local).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 56, 41, 490, DateTimeKind.Local).AddTicks(3620), "dNT5t6dK9S0fgNR+absKZgfnDVIwSdAOxfgb4FXLpuGbgBfz+bnvEFOEjjwRCe81", new DateTime(2024, 9, 11, 13, 56, 41, 490, DateTimeKind.Local).AddTicks(3670) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6270), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6260), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6310), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6320), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6320), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6330), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6200), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6250), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6250), new DateTime(2024, 9, 11, 13, 47, 40, 989, DateTimeKind.Local).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 13, 47, 40, 979, DateTimeKind.Local).AddTicks(7330), "XSU3HSdVAgQXEaIJL7a/12us1N6r21gVkhNeuo/zK0rtT/H2rQC8l5Hte713OA1r", new DateTime(2024, 9, 11, 13, 47, 40, 979, DateTimeKind.Local).AddTicks(7370) });
        }
    }
}
