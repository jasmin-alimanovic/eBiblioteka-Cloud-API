using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Biblioteka
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Grad { get; set; }
        public string Email { get; set; }
        public double CijenaClanarine { get; set; }

        //Korisnici
        public ICollection<Korisnik> Korisnici { get; set; }
        //Zaposlenici
        public ICollection<Zaposlenik> Zaposlenici { get; set; }
        //Nabavke
        public ICollection<KnjigaNabavka> Nabavka { get; set; }
    }
}
