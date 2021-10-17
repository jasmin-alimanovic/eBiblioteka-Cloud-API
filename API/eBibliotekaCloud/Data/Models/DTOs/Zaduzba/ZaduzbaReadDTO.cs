using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
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
        public bool IsZavrsena { get; set; }


        public KorisnikReadDTO Korisnik { get; set; }
        public KnjigaReadDTO Knjiga { get; set; }
    }
}
