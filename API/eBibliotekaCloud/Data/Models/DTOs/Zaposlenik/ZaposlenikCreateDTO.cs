using eBibliotekaCloud.Data.Models.DTOs.Kartica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Zaposlenik
{
    public class ZaposlenikCreateDTO
    {
        public string FirebaseId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int UlogaId { get; set; }
    }
}
