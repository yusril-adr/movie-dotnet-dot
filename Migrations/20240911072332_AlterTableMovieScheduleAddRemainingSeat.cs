using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableMovieScheduleAddRemainingSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "remaining_Seat",
                table: "Movie_Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1230), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1230), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1280), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(940), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1130), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1130), new DateTime(2024, 9, 11, 14, 23, 32, 292, DateTimeKind.Local).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 14, 23, 32, 282, DateTimeKind.Local).AddTicks(740), "yuYNLeITkjieBxXX8b04W0QvdyOWkOvIsZcJoNJSBzBlNSRU87q/bxQzO015ka71", new DateTime(2024, 9, 11, 14, 23, 32, 282, DateTimeKind.Local).AddTicks(810) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "remaining_Seat",
                table: "Movie_Schedules");

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
    }
}
