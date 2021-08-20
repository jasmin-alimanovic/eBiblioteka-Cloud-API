using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.ZaduzbaStavke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Zaduzba
{
    public class ZaduzbaReadDTO
    {
        public int Id { get; set; }
        public DateTime DatumZaduzbe { get; set; }
        public DateTime DatumPovratka { get; set; }
        public DateTime DatumVracanja { get; set; }
        public int Kolicina { get; set; }
        public bool IsZavrsena { get; set; }

        public ICollection<ZaduzbaStavkeReadDTO> Stavke { get; set; }

        public KorisnikReadDTO Korisnik { get; set; }
    }
}
