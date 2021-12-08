using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Izdavac
{
    public class IzdavacReadDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sjediste { get; set; }

    }
}
