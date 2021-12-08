using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models
{
    public class KnjigaZanr
    {
        public int KnjigaId { get; set; }
        public Knjiga Knjiga{ get; set; }

        public int ZanrId { get; set; }
        public Zanr Zanr { get; set; }

    }
}
