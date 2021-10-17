using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Knjiga
{
    public class KnjigaCreateDto
    {
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string ISBN { get; set; }
        public int GodinaIzdavanja { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public string Izdanje { get; set; }
        public int Ukupno { get; set; } //ukupan broj knjiga(dostupnih i nedostupnih)
        [Required]
        public string Pismo { get; set; }


        //FK za autora
        [Required]
        public int AutorId { get; set; }


        //FK za Izdavac
        [Required]
        public int IzdavacId { get; set; }

        //FK za Jezik
        [Required]
        public int JezikId { get; set; }

        //FK za kategoriju
        [Required]
        public int KategorijaId { get; set; }

    }
}
