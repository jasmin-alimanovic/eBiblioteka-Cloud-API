using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Zaposlenik
{
    public class ZaposlenikReadDTO
    {
        public int Id { get; set; }
        public string FirebaseId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }


        //FK za karticu
        //public ICollection<Kartica> Kartice { get; set; }


        //FK za ulogu
        public eBibliotekaCloud.Models.Uloga Uloga { get; set; }
    }
}
