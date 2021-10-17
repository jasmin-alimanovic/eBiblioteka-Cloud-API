using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Izdavac;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class IzdavacProfile : Profile
    {
        public IzdavacProfile()
        {
            CreateMap<Izdavac, IzdavacReadDTO>();
            CreateMap<IzdavacCreateDTO, Izdavac>();
        }
    }
}
