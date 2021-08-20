using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Zaduzba
{
    public class ZaduzbaUpdateDTO
    {
        public DateTime DatumZaduzbe { get; set; }
        public DateTime DatumPovratka { get; set; }
        public DateTime DatumVracanja { get; set; }
        public int Kolicina { get; set; }

        public int KorisnikId { get; set; }
    }
}
