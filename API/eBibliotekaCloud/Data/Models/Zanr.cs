using eBibliotekaCloud.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        //Knjige
        public ICollection<KnjigaZanr> KnjigaZanr { get; set; }

    }
}
