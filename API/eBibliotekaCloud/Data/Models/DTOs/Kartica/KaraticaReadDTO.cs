using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Kartica
{
    public class KarticaReadDTO
    {
        public int Id { get; set; }
        public string BrojKartice { get; set; }
        public string DtmIsteka { get; set; }
        public int CVV { get; set; }
        public string Vlasnik { get; set; }

        public KorisnikReadDTO Korisnik { get; set; }
    }
}
