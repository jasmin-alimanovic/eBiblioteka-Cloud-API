using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Kartica
    {
        public int Id { get; set; }
        public string BrojKartice { get; set; }
        public string DtmIsteka { get; set; }
        public int CVV { get; set; }
        public string Vlasnik { get; set; }

        //FK Korisnik
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        //FK Zaposlenik
        //public int ZaposlenikId { get; set; }
        //public Zaposlenik Zaposlenik { get; set; }
    }
}
