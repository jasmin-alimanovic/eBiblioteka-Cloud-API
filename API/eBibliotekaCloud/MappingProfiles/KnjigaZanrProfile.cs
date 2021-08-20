using AutoMapper;
using eBibliotekaCloud.Data.Models;
using eBibliotekaCloud.Data.Models.DTOs.KnjigaZanr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class KnjigaZanrProfile:Profile
    {
        public KnjigaZanrProfile()
        {
            CreateMap<KnjigaZanr, KnjigaZanrReadDTO>();
        }
    }
}
