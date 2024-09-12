using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_users_user_id",
                table: "Orders",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_users_user_id",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "Users",
                newName: "IX_Users_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
