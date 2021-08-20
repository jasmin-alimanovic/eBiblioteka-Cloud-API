using eBibliotekaCloud.Data.Models.DTOs.Kartica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Korisnik
{
    public class KorisnikReadDTO
    {
        public int Id { get; set; }
        public string FirebaseId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public bool IsUclanjen { get; set; }

        public ICollection<KarticaReadDTO> Kartice { get; set; }
    }
}
