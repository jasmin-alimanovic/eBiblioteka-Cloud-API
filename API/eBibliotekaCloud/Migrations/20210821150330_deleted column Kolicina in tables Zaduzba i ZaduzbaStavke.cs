using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class deletedcolumnKolicinaintablesZaduzbaiZaduzbaStavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Zaduzbe");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "StavkeZaduzbi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Zaduzbe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "StavkeZaduzbi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
