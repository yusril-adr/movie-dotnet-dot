using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dot_dotnet_test_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableMovieAndTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", nullable: false),
                    overview = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    poster = table.Column<string>(type: "varchar(255)", nullable: false),
                    play_until = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Tags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movie_id = table.Column<long>(type: "bigint", nullable: true),
                    tag_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Tags", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movie_Tags_Movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Movie_Tags_Tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "Tags",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "created_at", "deleted_at", "overview", "play_until", "poster", "title", "updated_at" },
                values: new object[] { 9981L, new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1150), null, "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.", new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1150), "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg", "Avengers: Age of Ultron", new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1150) });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "id", "created_at", "deleted_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1090), null, "Action", new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1090) },
                    { 2L, new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1130), null, "Comedy", new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1130) },
                    { 3L, new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1140), null, "Fantasy", new DateTime(2024, 9, 11, 8, 6, 7, 228, DateTimeKind.Local).AddTicks(1140) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "avatar", "created_at", "deleted_at", "email", "is_admin", "name", "password", "updated_at" },
                values: new object[] { 1L, "./files/images/avatar/example.png", new DateTime(2024, 9, 11, 8, 6, 7, 217, DateTimeKind.Local).AddTicks(7940), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@getnada.com", false, "user test", "9+2y7gb8BRn91FPWXJ5iculKdqFPOxBP0AKUsfSiogFMyqr+CwKkO6TcVRbStFJY", new DateTime(2024, 9, 11, 8, 6, 7, 217, DateTimeKind.Local).AddTicks(7980) });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Tags_movie_id",
                table: "Movie_Tags",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Tags_tag_id",
                table: "Movie_Tags",
                column: "tag_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Tags");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
