using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Zaduzba
    {
        public int Id { get; set; }
        public DateTime DatumZaduzbe { get; set; }
        public DateTime DatumPovratka { get; set; }
        public DateTime DatumVracanja { get; set; }
        public int Kolicina { get; set; }
        public bool IsZavrsena { get; set; }

        public ICollection<ZaduzbaStavke> Stavke { get; set; }

        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }




        public Zaduzba()
        {
            IsZavrsena = false;
            Kolicina = 1;
            DatumZaduzbe = DateTime.Now;
            DatumPovratka = DatumZaduzbe + new TimeSpan(15, 0, 0, 0);

        }
   
    }
}
