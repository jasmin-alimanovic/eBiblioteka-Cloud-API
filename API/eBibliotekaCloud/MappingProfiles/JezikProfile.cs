using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Jezik;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class JezikProfile : Profile
    {
        public JezikProfile()
        {
            CreateMap<Jezik, JezikReadDTO>();
            CreateMap<JezikCreateDTO, Jezik>();
        }
    }
}
