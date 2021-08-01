using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eBibliotekaCloud.Migrations
{
    public partial class pocetnamigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CijenaClanarine = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Izdavaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sjediste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdavaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jezici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jezici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zanrovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanrovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirebaseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUclanjen = table.Column<bool>(type: "bit", nullable: false),
                    BibliotekaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Biblioteke_BibliotekaId",
                        column: x => x.BibliotekaId,
                        principalTable: "Biblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Knjige",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodinaIzdavanja = table.Column<int>(type: "int", nullable: false),
                    KratkiOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DugiOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popust = table.Column<double>(type: "float", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Dostupno = table.Column<int>(type: "int", nullable: false),
                    Ukupno = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Izdanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pismo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    IzdavacId = table.Column<int>(type: "int", nullable: false),
                    JezikId = table.Column<int>(type: "int", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knjige_Autori_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Knjige_Izdavaci_IzdavacId",
                        column: x => x.IzdavacId,
                        principalTable: "Izdavaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Knjige_Jezici_JezikId",
                        column: x => x.JezikId,
                        principalTable: "Jezici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Knjige_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirebaseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    BibliotekaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenci_Biblioteke_BibliotekaId",
                        column: x => x.BibliotekaId,
                        principalTable: "Biblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenci_Uloge_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kartice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtmIsteka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    Vlasnik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kartice_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaduzbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumZaduzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPovratka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVracanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    IsZavrsena = table.Column<bool>(type: "bit", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaduzbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaduzbe_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnjigaZanr",
                columns: table => new
                {
                    KnjigeId = table.Column<int>(type: "int", nullable: false),
                    ZanroviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjigaZanr", x => new { x.KnjigeId, x.ZanroviId });
                    table.ForeignKey(
                        name: "FK_KnjigaZanr_Knjige_KnjigeId",
                        column: x => x.KnjigeId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnjigaZanr_Zanrovi_ZanroviId",
                        column: x => x.ZanroviId,
                        principalTable: "Zanrovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NabakveKnjiga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<int>(type: "int", nullable: false),
                    DatumNabavke = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    BibliotekaId = table.Column<int>(type: "int", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabakveKnjiga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabakveKnjiga_Biblioteke_BibliotekaId",
                        column: x => x.BibliotekaId,
                        principalTable: "Biblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabakveKnjiga_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeZaduzbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVracena = table.Column<bool>(type: "bit", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    KnjigaId = table.Column<int>(type: "int", nullable: false),
                    ZaduzbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeZaduzbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeZaduzbi_Knjige_KnjigaId",
                        column: x => x.KnjigaId,
                        principalTable: "Knjige",
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
                name: "IX_Kartice_KorisnikId",
                table: "Kartice",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KnjigaZanr_ZanroviId",
                table: "KnjigaZanr",
                column: "ZanroviId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_AutorId",
                table: "Knjige",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_IzdavacId",
                table: "Knjige",
                column: "IzdavacId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_JezikId",
                table: "Knjige",
                column: "JezikId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_KategorijaId",
                table: "Knjige",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_BibliotekaId",
                table: "Korisnici",
                column: "BibliotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabakveKnjiga_BibliotekaId",
                table: "NabakveKnjiga",
                column: "BibliotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabakveKnjiga_KnjigaId",
                table: "NabakveKnjiga",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeZaduzbi_KnjigaId",
                table: "StavkeZaduzbi",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeZaduzbi_ZaduzbaId",
                table: "StavkeZaduzbi",
                column: "ZaduzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzbe_KorisnikId",
                table: "Zaduzbe",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenci_BibliotekaId",
                table: "Zaposlenci",
                column: "BibliotekaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenci_UlogaId",
                table: "Zaposlenci",
                column: "UlogaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kartice");

            migrationBuilder.DropTable(
                name: "KnjigaZanr");

            migrationBuilder.DropTable(
                name: "NabakveKnjiga");

            migrationBuilder.DropTable(
                name: "StavkeZaduzbi");

            migrationBuilder.DropTable(
                name: "Zaposlenci");

            migrationBuilder.DropTable(
                name: "Zanrovi");

            migrationBuilder.DropTable(
                name: "Knjige");

            migrationBuilder.DropTable(
                name: "Zaduzbe");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Izdavaci");

            migrationBuilder.DropTable(
                name: "Jezici");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Biblioteke");
        }
    }
}
