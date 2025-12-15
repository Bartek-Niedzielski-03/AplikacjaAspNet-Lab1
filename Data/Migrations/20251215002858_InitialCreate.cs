using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Artist = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    List = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    release_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    music_type = table.Column<int>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "Id", "Artist", "created", "Duration", "List", "music_type", "Position", "release_date", "Title" },
                values: new object[] { 1, "Test Artist", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, "Track1; Track2", 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Album" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "albums");
        }
    }
}
