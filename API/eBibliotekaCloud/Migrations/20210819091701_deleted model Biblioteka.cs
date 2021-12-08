using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class deletedmodelBiblioteka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Biblioteke_BibliotekaId",
                table: "Korisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_NabakveKnjiga_Biblioteke_BibliotekaId",
                table: "NabakveKnjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_Zaposlenci_Biblioteke_BibliotekaId",
                table: "Zaposlenci");

            migrationBuilder.DropTable(
                name: "Biblioteke");

            migrationBuilder.DropIndex(
                name: "IX_Zaposlenci_BibliotekaId",
                table: "Zaposlenci");

            migrationBuilder.DropIndex(
                name: "IX_NabakveKnjiga_BibliotekaId",
                table: "NabakveKnjiga");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_BibliotekaId",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "BibliotekaId",
                table: "Zaposlenci");

            migrationBuilder.DropColumn(
                name: "BibliotekaId",
                table: "NabakveKnjiga");

            migrationBuilder.DropColumn(
                name: "BibliotekaId",
                table: "Korisnici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BibliotekaId",
                table: "Zaposlenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BibliotekaId",
                table: "NabakveKnjiga",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BibliotekaId",
                table: "Korisnici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Biblioteke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CijenaClanarine = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteke", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenci_BibliotekaId",
                table: "Zaposlenci",
                column: "BibliotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabakveKnjiga_BibliotekaId",
                table: "NabakveKnjiga",
                column: "BibliotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_BibliotekaId",
                table: "Korisnici",
                column: "BibliotekaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Biblioteke_BibliotekaId",
                table: "Korisnici",
                column: "BibliotekaId",
                principalTable: "Biblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NabakveKnjiga_Biblioteke_BibliotekaId",
                table: "NabakveKnjiga",
                column: "BibliotekaId",
                principalTable: "Biblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zaposlenci_Biblioteke_BibliotekaId",
                table: "Zaposlenci",
                column: "BibliotekaId",
                principalTable: "Biblioteke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
