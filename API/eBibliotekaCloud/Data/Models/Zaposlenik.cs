using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Zaposlenik
    {
        public int Id { get; set; }
        public string FirebaseId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }


        //FK za karticu
        //public ICollection<Kartica> Kartice { get; set; }


        //FK za ulogu
        public int UlogaId { get; set; }
        public Uloga Uloga { get; set; }

    }
}
