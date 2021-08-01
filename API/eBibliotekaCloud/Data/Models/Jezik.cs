using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Jezik
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        //knjige
        public ICollection<Knjiga> Knjige { get; set; }
    }
}
