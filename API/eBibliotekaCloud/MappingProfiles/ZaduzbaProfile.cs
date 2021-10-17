using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Zaduzba;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class ZaduzbaProfile : Profile
    {
        public ZaduzbaProfile()
        {
            CreateMap<Zaduzba, ZaduzbaReadDTO>();
            CreateMap<ZaduzbaUpdateDTO, Zaduzba>();
            CreateMap<ZaduzbaCreateDTO, Zaduzba>();
        }
    }
}
