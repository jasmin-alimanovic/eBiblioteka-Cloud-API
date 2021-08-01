using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class KnjigaNabavka
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public DateTime DatumNabavke { get; set; }
        public int Kolicina { get; set; }

        public int BibliotekaId { get; set; }
        public Biblioteka Biblioteka{ get; set; }

        public int KnjigaId { get; set; }
        public Knjiga Knjiga { get; set; }

    }
}
