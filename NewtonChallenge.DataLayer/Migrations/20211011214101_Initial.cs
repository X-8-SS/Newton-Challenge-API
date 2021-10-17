using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtonChallenge.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    VideoGameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    RatingId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((6))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.VideoGameId);
                    table.ForeignKey(
                        name: "FK_VideoGames_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoGames_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action games" },
                    { 2, "Platform games" },
                    { 3, "Shooter games" },
                    { 4, "Fighting games" },
                    { 5, "Stealth game" },
                    { 6, "Survival games" },
                    { 7, "Rhythm games" },
                    { 8, "Battle Royale games" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Category", "Description" },
                values: new object[,]
                {
                    { 1, "E", "Everyone" },
                    { 2, "E10+", "Everyone 10+" },
                    { 3, "T", "Teen" },
                    { 4, "M", "Mature" },
                    { 5, "A", "Adults" },
                    { 6, "RP", "Rating Pending" }
                });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "VideoGameId", "GenreId", "Price", "RatingId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 20.00m, 1, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Video game one" },
                    { 2, 2, 24.00m, 3, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Video game two" },
                    { 3, 3, 27.00m, 4, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Video game three" },
                    { 4, 4, 30.00m, 5, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Video game four" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_GenreId",
                table: "VideoGames",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_RatingId",
                table: "VideoGames",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
