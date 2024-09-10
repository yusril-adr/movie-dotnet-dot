using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    movie_id = table.Column<long>(type: "bigint", nullable: false),
                    tag_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TagId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Tags", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movie_Tags_Movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Tags_Tags_TagId1",
                        column: x => x.TagId1,
                        principalTable: "Tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id", "created_at", "deleted_at", "overview", "play_until", "poster", "title", "updated_at" },
                values: new object[] { 9981L, new DateTime(2024, 9, 10, 14, 17, 40, 586, DateTimeKind.Local).AddTicks(8950), null, "When Tony Stark tries to jumpstart a dormant peacekeeping program, things go awry and Earth’s Mightiest Heroes are put to the ultimate test as the fate of the planet hangs in the balance. As the villainous Ultron emerges, it is up to The Avengers to stop him from enacting his terrible plans, and soon uneasy alliances and unexpected action pave the way for an epic and unique global adventure.", new DateTime(2024, 9, 10, 14, 17, 40, 586, DateTimeKind.Local).AddTicks(8940), "https://image.tmdb.org/t/p/original/4ssDuvEDkSArWEdyBl2X5EHvYKU.jpg", "Avengers: Age of Ultron", new DateTime(2024, 9, 10, 14, 17, 40, 586, DateTimeKind.Local).AddTicks(8950) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "avatar", "created_at", "deleted_at", "email", "is_admin", "name", "password", "updated_at" },
                values: new object[] { 1L, "./files/images/avatar/example.png", new DateTime(2024, 9, 10, 14, 17, 40, 576, DateTimeKind.Local).AddTicks(2430), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@getnada.com", false, "user test", "Auje5q9ZIDcuN92i5aWt4f55XbEhCBQ5wKIrh6fS7IrSy1L0aUulEEUl4TWRSttn", new DateTime(2024, 9, 10, 14, 17, 40, 576, DateTimeKind.Local).AddTicks(2470) });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Tags_movie_id",
                table: "Movie_Tags",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Tags_TagId1",
                table: "Movie_Tags",
                column: "TagId1");
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
