using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        //knjige
        public ICollection<Knjiga> Knjige { get; set; }

    }
}
