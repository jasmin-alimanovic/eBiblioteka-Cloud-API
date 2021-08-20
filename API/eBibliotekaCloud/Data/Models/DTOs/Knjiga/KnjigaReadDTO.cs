using eBibliotekaCloud.Data.Models.DTOs.Autor;
using eBibliotekaCloud.Data.Models.DTOs.Izdavac;
using eBibliotekaCloud.Data.Models.DTOs.Jezik;
using eBibliotekaCloud.Data.Models.DTOs.Kategorija;
using eBibliotekaCloud.Data.Models.DTOs.KnjigaZanr;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Knjiga
{
    public class KnjigaReadDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string ISBN { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string KratkiOpis { get; set; }
        public string DugiOpis { get; set; }
        public double Popust { get; set; }
        public double Cijena { get; set; }
        public int Dostupno { get; set; } //broj knjiga koje su dostupne
        public int Ukupno { get; set; } //ukupan broj knjiga(dostupnih i nedostupnih)
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public string Izdanje { get; set; }
        public string Pismo { get; set; }


        //FK za autora
        public AutorReadDTO Autor { get; set; }


        //FK za Izdavac
        public IzdavacReadDTO Izdavac { get; set; }

        //FK za Jezik
        public JezikReadDTO Jezik { get; set; }

        //FK za kategoriju
        public KategorijaReadDTO Kategorija { get; set; }

        //FK za zanrove
        public ICollection<KnjigaZanrReadDTO> KnjigaZanr { get; set; }
    }
}
