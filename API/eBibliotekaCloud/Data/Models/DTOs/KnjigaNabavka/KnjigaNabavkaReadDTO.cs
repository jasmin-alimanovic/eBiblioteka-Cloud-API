using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.KnjigaNabavka
{
    public class KnjigaNabavkaReadDTO
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public DateTime DatumNabavke { get; set; }
        public int Kolicina { get; set; }

        public KnjigaReadDTO Knjiga { get; set; }
    }
}
