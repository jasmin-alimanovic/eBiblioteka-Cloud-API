using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Kartica;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class KarticaProfile : Profile
    {
        public KarticaProfile()
        {
            CreateMap<Kartica, KarticaReadDTO>();
            CreateMap<KarticaCreateDTO, Kartica>();
        }
    }
}
