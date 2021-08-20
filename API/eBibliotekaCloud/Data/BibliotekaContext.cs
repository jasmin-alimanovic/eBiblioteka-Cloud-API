using eBibliotekaCloud.Data.EntityConfig;
using eBibliotekaCloud.Data.Models;
using eBibliotekaCloud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data
{
    public class BibliotekaContext:DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Zaposlenik> Zaposlenci { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<KnjigaNabavka> NabakveKnjiga { get; set; }
        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<KnjigaZanr> KnjigaZanr { get; set; }
        public DbSet<Izdavac> Izdavaci { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Zaduzba> Zaduzbe { get; set; }
        public DbSet<ZaduzbaStavke> StavkeZaduzbi { get; set; }
        public DbSet<Autor> Autori { get; set; }
        public DbSet<Jezik> Jezici { get; set; }
        public DbSet<Kartica> Kartice { get; set; }
        public DbSet<Uloga> Uloge { get; set; }
        
        public BibliotekaContext(DbContextOptions<BibliotekaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnjigaZanr>()
                .HasKey(i => new { i.KnjigaId, i.ZanrId });

            modelBuilder.Entity<KnjigaZanr>()
                .HasOne(kz => kz.Knjiga)
                .WithMany(k => k.KnjigaZanr)
                .HasForeignKey(kz => kz.KnjigaId);
            modelBuilder.Entity<KnjigaZanr>()
                .HasOne(kz => kz.Zanr)
                .WithMany(z => z.KnjigaZanr)
                .HasForeignKey(kz => kz.ZanrId);
            modelBuilder.ApplyConfiguration(new KnjigaConfig());
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
