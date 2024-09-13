using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTableTodoAndWeatherForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5380), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5380), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5440), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5440), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5450), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5450), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5110), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5360), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5360) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5370), new DateTime(2024, 9, 13, 7, 30, 32, 298, DateTimeKind.Local).AddTicks(5370) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 13, 7, 30, 32, 287, DateTimeKind.Local).AddTicks(7910), "PKB1bwG/qzuelJgogmEjDDH8Rnw9tfvbA/rIobM+EyjDKDLmSXS1BZGCV+bo6hpV", new DateTime(2024, 9, 13, 7, 30, 32, 287, DateTimeKind.Local).AddTicks(7970) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_complete = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5000), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4990), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5050), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4890), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4980), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4980), new DateTime(2024, 9, 12, 17, 1, 43, 686, DateTimeKind.Local).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 12, 17, 1, 43, 676, DateTimeKind.Local).AddTicks(5850), "zADSZixXx18SrD3L+kyTPThWXaZpGqYvdREzqWXkMl/kwodUPUoCSpg/9FMa9TCP", new DateTime(2024, 9, 12, 17, 1, 43, 676, DateTimeKind.Local).AddTicks(5970) });
        }
    }
}
