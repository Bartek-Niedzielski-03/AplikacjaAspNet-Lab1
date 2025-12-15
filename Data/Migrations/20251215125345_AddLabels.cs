using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "albums",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "LabelId",
                table: "albums",
                type: "INTEGER",
                nullable: false,
                defaultValue: 101);

            migrationBuilder.CreateTable(
                name: "labels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Nip = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Regon = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labels", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "LabelId",
                value: 101);

            migrationBuilder.InsertData(
                table: "labels",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "Nip", "Regon", "Title" },
                values: new object[,]
                {
                    { 101, "Kraków", "31-150", "małopolskie", "Św. Filipa 17", "1111111111", "2222222222", "Universal Music" },
                    { 102, "Warszawa", "00-001", "mazowieckie", "Marszałkowska 1", "3333333333", "4444444444", "Sony Music" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_LabelId",
                table: "albums",
                column: "LabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_labels_LabelId",
                table: "albums",
                column: "LabelId",
                principalTable: "labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_labels_LabelId",
                table: "albums");

            migrationBuilder.DropTable(
                name: "labels");

            migrationBuilder.DropIndex(
                name: "IX_albums_LabelId",
                table: "albums");

            migrationBuilder.DropColumn(
                name: "LabelId",
                table: "albums");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "albums",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
