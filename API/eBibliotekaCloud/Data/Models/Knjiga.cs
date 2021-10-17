using eBibliotekaCloud.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string ISBN { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string Opis { get; set; }
        public int Dostupno { get; set; } //broj knjiga koje su dostupne
        public int Ukupno { get; set; } //ukupan broj knjiga(dostupnih i nedostupnih)
        public string ImageUrl { get; set; }
        public string PdfUrl { get; set; }
        public string Izdanje { get; set; }
        public string Pismo{ get; set; }
        public bool IsDeleted { get; set; }


        //FK za autora
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        //FK za KnjigaNabavka
        public ICollection<KnjigaNabavka> Nabavke{ get; set; }

        //FK za Izdavac
        public int IzdavacId { get; set; }
        public Izdavac Izdavac{ get; set; }

        //FK za Jezik
        public int JezikId { get; set; }
        public Jezik Jezik { get; set; }

        //FK za kategoriju
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }

        //FK za zanrove
        public ICollection<KnjigaZanr> KnjigaZanr { get; set; }
        public ICollection<Zaduzba> Zaduzbe { get; set; }


    }
}
