using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string FirebaseId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public bool IsUclanjen { get; set; }

        public ICollection<Kartica> Kartice { get; set; }

        //FK za biblioteku
        public int BibliotekaId { get; set; }
        public Biblioteka Biblioteka { get; set; }

    }
}
