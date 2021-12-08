using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Models
{
    public class Korisnik
    {
        public Korisnik()
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var utcDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
            DatumUclanjenja = utcDate;
            
        }
        public int Id { get; set; }
        public string FirebaseId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public bool IsUclanjen { get; set; }
        public DateTime DatumUclanjenja { get; set; }
        public ICollection<Zaduzba> Zaduzbe { get; set; }

        public ICollection<Kartica> Kartice { get; set; }


    }
}
