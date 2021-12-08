using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.KnjigaNabavka
{
    public class KnjigaNabavkaCreateDTO
    {
        public int Sifra { get; set; }
        public DateTime DatumNabavke { get; set; }
        public int Kolicina { get; set; }

        public int KnjigaId{ get; set; }
    }
}
