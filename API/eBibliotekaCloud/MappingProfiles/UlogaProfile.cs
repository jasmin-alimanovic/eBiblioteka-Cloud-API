using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Uloga;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class UlogaProfile : Profile
    {
        public UlogaProfile()
        {
            CreateMap<UlogaCreateDTO, Uloga>();
        }
    }
}
