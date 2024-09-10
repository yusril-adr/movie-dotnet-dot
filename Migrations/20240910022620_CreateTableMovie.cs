using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    overview = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    poster = table.Column<string>(type: "varchar(255)", nullable: false),
                    play_until = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "created_at", "deleted_at", "overview", "play_until", "poster", "title", "updated_at" },
                values: new object[] { 9981, new DateTime(2024, 9, 10, 9, 26, 19, 788, DateTimeKind.Local).AddTicks(4510), null, "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.", new DateTime(2024, 9, 10, 9, 26, 19, 788, DateTimeKind.Local).AddTicks(4500), "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg", "Avengers: Age of Ultron", new DateTime(2024, 9, 10, 9, 26, 19, 788, DateTimeKind.Local).AddTicks(4510) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "avatar", "created_at", "deleted_at", "email", "is_admin", "name", "password", "updated_at" },
                values: new object[] { 1L, "./files/images/avatar/example.png", new DateTime(2024, 9, 10, 9, 26, 19, 777, DateTimeKind.Local).AddTicks(5600), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@getnada.com", false, "user test", "k6dxTvBuhiPgAmrBs3pOBAoTOYPt239jynfV2YFj7F7G6n6pzCbIU69Vi/iZ8q8Y", new DateTime(2024, 9, 10, 9, 26, 19, 777, DateTimeKind.Local).AddTicks(5630) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
