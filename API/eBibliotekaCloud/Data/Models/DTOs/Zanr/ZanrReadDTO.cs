﻿using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Data.Models.DTOs.Zanr
{
    public class ZanrReadDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        //Knjige
        //public ICollection<KnjigaReadDTO> Knjige { get; set; }
    }
}
