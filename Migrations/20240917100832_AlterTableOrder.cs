using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7260), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7260) });

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7290), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "movie_tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7210), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "id", "created_at", "deleted_at", "overview", "play_until", "poster", "title", "updated_at" },
                values: new object[] { 24428L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160), null, "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!", new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7160), "https://image.tmdb.org/t/p/original/RYMX2wcKCBAr24UyPD7xwmjaTn.jpg", "The Avengers", new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7170) });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "created_at", "deleted_at", "total_item_price", "updated_at", "user_id" },
                values: new object[] { 1L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7310), null, 60000, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7310), 1L });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7220), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7230), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7240), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7250), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7090), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140), new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 8, 32, 173, DateTimeKind.Local).AddTicks(8760), "hJ/YEEHqSaSEx6+hEn1c5XdO3siizSMdTbzI1jwTtTZbkAmHhbKytJB1rn+ERZ+p", new DateTime(2024, 9, 17, 17, 8, 32, 173, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.InsertData(
                table: "movie_schedules",
                columns: new[] { "id", "created_at", "date", "deleted_at", "end_time", "movie_id", "price", "remaining_Seat", "start_time", "studio_id", "updated_at" },
                values: new object[,]
                {
                    { 3L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7270), new DateOnly(2024, 9, 17), null, "10:00", 24428L, 15000, 50, "08:00", 1L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7270) },
                    { 4L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7300), new DateOnly(2024, 9, 17), null, "10:30", 24428L, 15000, 50, "08:30", 2L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7300) }
                });

            migrationBuilder.InsertData(
                table: "order_items",
                columns: new[] { "id", "created_at", "deleted_at", "movie_schedule_id", "order_id", "price", "qty", "sub_total_price", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7330), null, 1L, 1L, null, 3, 45000, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7330) },
                    { 2L, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7340), null, 3L, 1L, null, 1, 15000, new DateTime(2024, 9, 17, 17, 8, 32, 183, DateTimeKind.Local).AddTicks(7340) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "order_items",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "id",
                keyValue: 24428L);

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1780), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1790), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "movie_tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1710), new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1710) });

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
    }
}
