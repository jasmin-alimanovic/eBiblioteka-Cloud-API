using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Kategorija;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class KategorijaProfile : Profile
    {
        public KategorijaProfile()
        {
            CreateMap<Kategorija, KategorijaReadDTO>();
        }
    }
}
