using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableNameStudioAndOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Schedules_Studios_studio_id",
                table: "Movie_Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Movie_Schedules_movie_schedule_id",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Items_Orders_order_id",
                table: "Order_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_users_user_id",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studios",
                table: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items");

            migrationBuilder.RenameTable(
                name: "Studios",
                newName: "studios");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Order_Items",
                newName: "order_items");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_user_id",
                table: "orders",
                newName: "IX_orders_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_order_id",
                table: "order_items",
                newName: "IX_order_items_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Items_movie_schedule_id",
                table: "order_items",
                newName: "IX_order_items_movie_schedule_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studios",
                table: "studios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_items",
                table: "order_items",
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
                name: "FK_Movie_Schedules_studios_studio_id",
                table: "Movie_Schedules",
                column: "studio_id",
                principalTable: "studios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_Movie_Schedules_movie_schedule_id",
                table: "order_items",
                column: "movie_schedule_id",
                principalTable: "Movie_Schedules",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_orders_order_id",
                table: "order_items",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Schedules_studios_studio_id",
                table: "Movie_Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_Movie_Schedules_movie_schedule_id",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_orders_order_id",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studios",
                table: "studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_items",
                table: "order_items");

            migrationBuilder.RenameTable(
                name: "studios",
                newName: "Studios");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "order_items",
                newName: "Order_Items");

            migrationBuilder.RenameIndex(
                name: "IX_orders_user_id",
                table: "Orders",
                newName: "IX_Orders_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_order_id",
                table: "Order_Items",
                newName: "IX_Order_Items_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_movie_schedule_id",
                table: "Order_Items",
                newName: "IX_Order_Items_movie_schedule_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studios",
                table: "Studios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Items",
                table: "Order_Items",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Schedules_Studios_studio_id",
                table: "Movie_Schedules",
                column: "studio_id",
                principalTable: "Studios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Movie_Schedules_movie_schedule_id",
                table: "Order_Items",
                column: "movie_schedule_id",
                principalTable: "Movie_Schedules",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Items_Orders_order_id",
                table: "Order_Items",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_users_user_id",
                table: "Orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
