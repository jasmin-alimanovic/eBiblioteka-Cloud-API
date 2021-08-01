using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class PromijenjennazivtabeleizKnjigeuKnjiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnjigaZanr_Knjige_KnjigeId",
                table: "KnjigaZanr");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Autori_AutorId",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Izdavaci_IzdavacId",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Jezici_JezikId",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Kategorije_KategorijaId",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_NabakveKnjiga_Knjige_KnjigaId",
                table: "NabakveKnjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_StavkeZaduzbi_Knjige_KnjigaId",
                table: "StavkeZaduzbi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knjige",
                table: "Knjige");

            migrationBuilder.RenameTable(
                name: "Knjige",
                newName: "Knjiga");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_KategorijaId",
                table: "Knjiga",
                newName: "IX_Knjiga_KategorijaId");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_JezikId",
                table: "Knjiga",
                newName: "IX_Knjiga_JezikId");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_IzdavacId",
                table: "Knjiga",
                newName: "IX_Knjiga_IzdavacId");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_AutorId",
                table: "Knjiga",
                newName: "IX_Knjiga_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knjiga",
                table: "Knjiga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Autori_AutorId",
                table: "Knjiga",
                column: "AutorId",
                principalTable: "Autori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Izdavaci_IzdavacId",
                table: "Knjiga",
                column: "IzdavacId",
                principalTable: "Izdavaci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Jezici_JezikId",
                table: "Knjiga",
                column: "JezikId",
                principalTable: "Jezici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjiga_Kategorije_KategorijaId",
                table: "Knjiga",
                column: "KategorijaId",
                principalTable: "Kategorije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigaZanr_Knjiga_KnjigeId",
                table: "KnjigaZanr",
                column: "KnjigeId",
                principalTable: "Knjiga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NabakveKnjiga_Knjiga_KnjigaId",
                table: "NabakveKnjiga",
                column: "KnjigaId",
                principalTable: "Knjiga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeZaduzbi_Knjiga_KnjigaId",
                table: "StavkeZaduzbi",
                column: "KnjigaId",
                principalTable: "Knjiga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Autori_AutorId",
                table: "Knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Izdavaci_IzdavacId",
                table: "Knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Jezici_JezikId",
                table: "Knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjiga_Kategorije_KategorijaId",
                table: "Knjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_KnjigaZanr_Knjiga_KnjigeId",
                table: "KnjigaZanr");

            migrationBuilder.DropForeignKey(
                name: "FK_NabakveKnjiga_Knjiga_KnjigaId",
                table: "NabakveKnjiga");

            migrationBuilder.DropForeignKey(
                name: "FK_StavkeZaduzbi_Knjiga_KnjigaId",
                table: "StavkeZaduzbi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knjiga",
                table: "Knjiga");

            migrationBuilder.RenameTable(
                name: "Knjiga",
                newName: "Knjige");

            migrationBuilder.RenameIndex(
                name: "IX_Knjiga_KategorijaId",
                table: "Knjige",
                newName: "IX_Knjige_KategorijaId");

            migrationBuilder.RenameIndex(
                name: "IX_Knjiga_JezikId",
                table: "Knjige",
                newName: "IX_Knjige_JezikId");

            migrationBuilder.RenameIndex(
                name: "IX_Knjiga_IzdavacId",
                table: "Knjige",
                newName: "IX_Knjige_IzdavacId");

            migrationBuilder.RenameIndex(
                name: "IX_Knjiga_AutorId",
                table: "Knjige",
                newName: "IX_Knjige_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knjige",
                table: "Knjige",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigaZanr_Knjige_KnjigeId",
                table: "KnjigaZanr",
                column: "KnjigeId",
                principalTable: "Knjige",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Autori_AutorId",
                table: "Knjige",
                column: "AutorId",
                principalTable: "Autori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Izdavaci_IzdavacId",
                table: "Knjige",
                column: "IzdavacId",
                principalTable: "Izdavaci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Jezici_JezikId",
                table: "Knjige",
                column: "JezikId",
                principalTable: "Jezici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Kategorije_KategorijaId",
                table: "Knjige",
                column: "KategorijaId",
                principalTable: "Kategorije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NabakveKnjiga_Knjige_KnjigaId",
                table: "NabakveKnjiga",
                column: "KnjigaId",
                principalTable: "Knjige",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeZaduzbi_Knjige_KnjigaId",
                table: "StavkeZaduzbi",
                column: "KnjigaId",
                principalTable: "Knjige",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
