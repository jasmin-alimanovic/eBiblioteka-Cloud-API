using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using eBibliotekaCloud.Data.Models.DTOs.Zaduzba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.ZaduzbaStavke
{
    public class ZaduzbaStavkeReadDTO
    {
        public int Id { get; set; }
        public bool IsVracena { get; set; }
        public int Kolicina { get; set; }

        //foreign key za knjigu
        public KnjigaReadDTO Knjiga { get; set; }

        //foreign key za zaduzbu
        public ZaduzbaReadDTO Zaduzba { get; set; }
    }
}
