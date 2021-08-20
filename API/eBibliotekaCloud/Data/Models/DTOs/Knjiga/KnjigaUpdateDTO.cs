using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Knjiga
{
    public class KnjigaUpdateDTO
    {
        public string Naziv { get; set; }
        public string KratkiOpis { get; set; }
        public string DugiOpis { get; set; }
        public double Popust { get; set; }
        public double Cijena { get; set; }
        public int Dostupno { get; set; } //broj knjiga koje su dostupne
        public int Ukupno { get; set; } //ukupan broj knjiga(dostupnih i nedostupnih)
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public bool IsDeleted { get; set; }


        //FK za autora
        public int AutorId { get; set; }

        //FK za Izdavac
        public int IzdavacId { get; set; }

        //FK za Jezik
        public int JezikId { get; set; }

        //FK za kategoriju
        public int KategorijaId { get; set; }
    }
}
