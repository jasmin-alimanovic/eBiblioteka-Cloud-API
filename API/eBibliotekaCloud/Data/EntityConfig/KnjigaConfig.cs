using eBibliotekaCloud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.EntityConfig
{
    public class KnjigaConfig : IEntityTypeConfiguration<Knjiga>
    {
        public void Configure(EntityTypeBuilder<Knjiga> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("Knjiga");

            builder
                .HasOne(t => t.Autor)
                .WithMany(a => a.Knjige)
                .HasForeignKey(t => t.AutorId);

            builder
                .HasOne(t => t.Izdavac)
                .WithMany(i => i.Knjige)
                .HasForeignKey(t => t.IzdavacId);

            builder
                .HasOne(t => t.Jezik)
                .WithMany(i => i.Knjige)
                .HasForeignKey(t => t.JezikId);

            builder.
                HasMany(t => t.Zanrovi)
                .WithMany(z => z.Knjige);
                
        }
    }
}
