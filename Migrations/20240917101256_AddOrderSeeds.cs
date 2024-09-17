using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "remaining_Seat", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(620), 47, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "movie_schedules",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(660), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "movie_tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(570), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: 9981L,
                columns: new[] { "created_at", "play_until", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(460), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(460), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "id", "created_at", "deleted_at", "overview", "play_until", "poster", "title", "updated_at" },
                values: new object[] { 24428L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(470), null, "When an unexpected enemy emerges and threatens global safety and security, Nick Fury, director of the international peacekeeping agency known as S.H.I.E.L.D., finds himself in need of a team to pull the world back from the brink of disaster. Spanning the globe, a daring recruitment effort begins!", new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(470), "https://image.tmdb.org/t/p/original/RYMX2wcKCBAr24UyPD7xwmjaTn.jpg", "The Avengers", new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(470) });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "created_at", "deleted_at", "total_item_price", "updated_at", "user_id" },
                values: new object[] { 1L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(680), null, 60000, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(680), 1L });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(600), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "studios",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(600), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(390), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(440), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(450), new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 17, 12, 55, 673, DateTimeKind.Local).AddTicks(2840), "AclkvCt6TWcv/GWFkTLTfRrGe9mO2rThzjc4pGUxT+bwxarFmWJhIhX41P7XqmT3", new DateTime(2024, 9, 17, 17, 12, 55, 673, DateTimeKind.Local).AddTicks(2900) });

            migrationBuilder.InsertData(
                table: "movie_schedules",
                columns: new[] { "id", "created_at", "date", "deleted_at", "end_time", "movie_id", "price", "remaining_Seat", "start_time", "studio_id", "updated_at" },
                values: new object[,]
                {
                    { 3L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(640), new DateOnly(2024, 9, 17), null, "10:00", 24428L, 15000, 49, "08:00", 1L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(640) },
                    { 4L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(660), new DateOnly(2024, 9, 17), null, "10:30", 24428L, 15000, 50, "08:30", 2L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(660) }
                });

            migrationBuilder.InsertData(
                table: "order_items",
                columns: new[] { "id", "created_at", "deleted_at", "movie_schedule_id", "order_id", "price", "qty", "sub_total_price", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(700), null, 1L, 1L, null, 3, 45000, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(700) },
                    { 2L, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(700), null, 3L, 1L, null, 1, 15000, new DateTime(2024, 9, 17, 17, 12, 55, 683, DateTimeKind.Local).AddTicks(710) }
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
                columns: new[] { "created_at", "remaining_Seat", "updated_at" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1780), 50, new DateTime(2024, 9, 17, 16, 38, 45, 217, DateTimeKind.Local).AddTicks(1780) });

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
