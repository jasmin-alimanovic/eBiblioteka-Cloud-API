using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class deletedsomecolumnsfromtableKnjiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "DugiOpis",
                table: "Knjiga");

            migrationBuilder.DropColumn(
                name: "Popust",
                table: "Knjiga");

            migrationBuilder.RenameColumn(
                name: "KratkiOpis",
                table: "Knjiga",
                newName: "Opis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "Knjiga",
                newName: "KratkiOpis");

            migrationBuilder.AddColumn<double>(
                name: "Cijena",
                table: "Knjiga",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DugiOpis",
                table: "Knjiga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Popust",
                table: "Knjiga",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
