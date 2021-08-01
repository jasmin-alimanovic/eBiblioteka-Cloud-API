using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Izdavac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sjediste { get; set; }

        //knjige
        public ICollection<Knjiga> Knjige { get; set; }

    }
}
