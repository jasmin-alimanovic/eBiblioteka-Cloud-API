using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class addedmodelKnjigaZanr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnjigaZanr_Knjiga_KnjigeId",
                table: "KnjigaZanr");

            migrationBuilder.DropForeignKey(
                name: "FK_KnjigaZanr_Zanrovi_ZanroviId",
                table: "KnjigaZanr");

            migrationBuilder.RenameColumn(
                name: "ZanroviId",
                table: "KnjigaZanr",
                newName: "ZanrId");

            migrationBuilder.RenameColumn(
                name: "KnjigeId",
                table: "KnjigaZanr",
                newName: "KnjigaId");

            migrationBuilder.RenameIndex(
                name: "IX_KnjigaZanr_ZanroviId",
                table: "KnjigaZanr",
                newName: "IX_KnjigaZanr_ZanrId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigaZanr_Knjiga_KnjigaId",
                table: "KnjigaZanr",
                column: "KnjigaId",
                principalTable: "Knjiga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigaZanr_Zanrovi_ZanrId",
                table: "KnjigaZanr",
                column: "ZanrId",
                principalTable: "Zanrovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnjigaZanr_Knjiga_KnjigaId",
                table: "KnjigaZanr");

            migrationBuilder.DropForeignKey(
                name: "FK_KnjigaZanr_Zanrovi_ZanrId",
                table: "KnjigaZanr");

            migrationBuilder.RenameColumn(
                name: "ZanrId",
                table: "KnjigaZanr",
                newName: "ZanroviId");

            migrationBuilder.RenameColumn(
                name: "KnjigaId",
                table: "KnjigaZanr",
                newName: "KnjigeId");

            migrationBuilder.RenameIndex(
                name: "IX_KnjigaZanr_ZanrId",
                table: "KnjigaZanr",
                newName: "IX_KnjigaZanr_ZanroviId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigaZanr_Knjiga_KnjigeId",
                table: "KnjigaZanr",
                column: "KnjigeId",
                principalTable: "Knjiga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigaZanr_Zanrovi_ZanroviId",
                table: "KnjigaZanr",
                column: "ZanroviId",
                principalTable: "Zanrovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
