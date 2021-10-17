using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.KnjigaNabavka;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class NabavkaProfile : Profile
    {
        public NabavkaProfile()
        {
            CreateMap<KnjigaNabavka, KnjigaNabavkaReadDTO>();
            CreateMap<KnjigaNabavkaCreateDTO, KnjigaNabavka>();
        }
    }
}
