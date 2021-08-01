﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eBibliotekaCloud.Data;

namespace eBibliotekaCloud.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    partial class BibliotekaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KnjigaZanr", b =>
                {
                    b.Property<int>("KnjigeId")
                        .HasColumnType("int");

                    b.Property<int>("ZanroviId")
                        .HasColumnType("int");

                    b.HasKey("KnjigeId", "ZanroviId");

                    b.HasIndex("ZanroviId");

                    b.ToTable("KnjigaZanr");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autori");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Biblioteka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CijenaClanarine")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Biblioteke");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Izdavac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sjediste")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Izdavaci");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Jezik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jezici");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Kartica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojKartice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("DtmIsteka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Vlasnik")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Kartice");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Knjiga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("Dostupno")
                        .HasColumnType("int");

                    b.Property<string>("DugiOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GodinaIzdavanja")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Izdanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IzdavacId")
                        .HasColumnType("int");

                    b.Property<int>("JezikId")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<string>("KratkiOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pismo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Popust")
                        .HasColumnType("float");

                    b.Property<int>("Ukupno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("IzdavacId");

                    b.HasIndex("JezikId");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Knjiga");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.KnjigaNabavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BibliotekaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumNabavke")
                        .HasColumnType("datetime2");

                    b.Property<int>("KnjigaId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("Sifra")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BibliotekaId");

                    b.HasIndex("KnjigaId");

                    b.ToTable("NabakveKnjiga");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BibliotekaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirebaseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUclanjen")
                        .HasColumnType("bit");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BibliotekaId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Uloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Zaduzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPovratka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumVracanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZaduzbe")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsZavrsena")
                        .HasColumnType("bit");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Zaduzbe");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.ZaduzbaStavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsVracena")
                        .HasColumnType("bit");

                    b.Property<int>("KnjigaId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("ZaduzbaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KnjigaId");

                    b.HasIndex("ZaduzbaId");

                    b.ToTable("StavkeZaduzbi");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Zanr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zanrovi");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Zaposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BibliotekaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirebaseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BibliotekaId");

                    b.HasIndex("UlogaId");

                    b.ToTable("Zaposlenci");
                });

            modelBuilder.Entity("KnjigaZanr", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Knjiga", null)
                        .WithMany()
                        .HasForeignKey("KnjigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Zanr", null)
                        .WithMany()
                        .HasForeignKey("ZanroviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Kartica", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Korisnik", "Korisnik")
                        .WithMany("Kartice")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Knjiga", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Autor", "Autor")
                        .WithMany("Knjige")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Izdavac", "Izdavac")
                        .WithMany("Knjige")
                        .HasForeignKey("IzdavacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Jezik", "Jezik")
                        .WithMany("Knjige")
                        .HasForeignKey("JezikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Izdavac");

                    b.Navigation("Jezik");

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.KnjigaNabavka", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Biblioteka", "Biblioteka")
                        .WithMany("Nabavka")
                        .HasForeignKey("BibliotekaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Knjiga", "Knjiga")
                        .WithMany("Nabavke")
                        .HasForeignKey("KnjigaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biblioteka");

                    b.Navigation("Knjiga");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Korisnik", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Biblioteka", "Biblioteka")
                        .WithMany("Korisnici")
                        .HasForeignKey("BibliotekaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biblioteka");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Zaduzba", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.ZaduzbaStavke", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Knjiga", "Knjiga")
                        .WithMany()
                        .HasForeignKey("KnjigaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Zaduzba", "Zaduzba")
                        .WithMany("Stavke")
                        .HasForeignKey("ZaduzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knjiga");

                    b.Navigation("Zaduzba");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Zaposlenik", b =>
                {
                    b.HasOne("eBibliotekaCloud.Models.Biblioteka", "Biblioteka")
                        .WithMany("Zaposlenici")
                        .HasForeignKey("BibliotekaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBibliotekaCloud.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biblioteka");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Autor", b =>
                {
                    b.Navigation("Knjige");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Biblioteka", b =>
                {
                    b.Navigation("Korisnici");

                    b.Navigation("Nabavka");

                    b.Navigation("Zaposlenici");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Izdavac", b =>
                {
                    b.Navigation("Knjige");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Jezik", b =>
                {
                    b.Navigation("Knjige");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Knjiga", b =>
                {
                    b.Navigation("Nabavke");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Korisnik", b =>
                {
                    b.Navigation("Kartice");
                });

            modelBuilder.Entity("eBibliotekaCloud.Models.Zaduzba", b =>
                {
                    b.Navigation("Stavke");
                });
#pragma warning restore 612, 618
        }
    }
}
