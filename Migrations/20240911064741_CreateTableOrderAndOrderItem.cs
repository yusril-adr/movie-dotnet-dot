using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableOrderAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    total_item_price = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    movie_schedule_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    sub_total_price = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Items_Movie_Schedules_movie_schedule_id",
                        column: x => x.movie_schedule_id,
                        principalTable: "Movie_Schedules",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Order_Items_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_movie_schedule_id",
                table: "Order_Items",
                column: "movie_schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_order_id",
                table: "Order_Items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9580), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9580), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9630), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "Studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640), new DateTime(2024, 9, 11, 10, 15, 21, 678, DateTimeKind.Local).AddTicks(9640) });

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
        }
    }
}
