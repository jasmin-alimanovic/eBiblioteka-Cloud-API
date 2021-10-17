using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class DeletedNarudzbaStavketable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkeZaduzbi");

            migrationBuilder.AddColumn<int>(
                name: "KnjigaId",
                table: "Zaduzbe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzbe_KnjigaId",
                table: "Zaduzbe",
                column: "KnjigaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaduzbe_Knjiga_KnjigaId",
                table: "Zaduzbe",
                column: "KnjigaId",
                principalTable: "Knjiga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaduzbe_Knjiga_KnjigaId",
                table: "Zaduzbe");

            migrationBuilder.DropIndex(
                name: "IX_Zaduzbe_KnjigaId",
                table: "Zaduzbe");

            migrationBuilder.DropColumn(
                name: "KnjigaId",
                table: "Zaduzbe");

            migrationBuilder.CreateTable(
                name: "StavkeZaduzbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVracena = table.Column<bool>(type: "bit", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: false),
                    ZaduzbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeZaduzbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeZaduzbi_Knjiga_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeZaduzbi_Zaduzbe_ZaduzbaId",
                        column: x => x.ZaduzbaId,
                        principalTable: "Zaduzbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkeZaduzbi_KnjigaId",
                table: "StavkeZaduzbi",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeZaduzbi_ZaduzbaId",
                table: "StavkeZaduzbi",
                column: "ZaduzbaId");
        }
    }
}
