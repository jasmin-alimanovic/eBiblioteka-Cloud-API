using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class ZaduzbaStavke
    {
        public int Id { get; set; }
        public bool IsVracena { get; set; }
        public int Kolicina { get; set; }

        //foreign key za knjigu
        public int KnjigaId { get; set; }
        public Knjiga Knjiga { get; set; }

        //foreign key za zaduzbu
        public int ZaduzbaId { get; set; }
        public Zaduzba Zaduzba { get; set; }

    }
}
