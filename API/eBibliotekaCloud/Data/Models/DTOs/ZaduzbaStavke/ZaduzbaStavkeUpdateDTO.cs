using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.ZaduzbaStavke
{
    public class ZaduzbaStavkeUpdateDTO
    {
        public int Kolicina { get; set; }

        //foreign key za knjigu
        public int KnjigaId { get; set; }

        //foreign key za zaduzbu
        public int ZaduzbaId { get; set; }
    }
}
