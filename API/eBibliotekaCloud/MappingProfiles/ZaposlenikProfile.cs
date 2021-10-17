using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Zaposlenik;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class ZaposlenikProfile : Profile
    {
        public ZaposlenikProfile()
        {
            CreateMap<Zaposlenik, ZaposlenikReadDTO>();
            CreateMap<ZaposlenikCreateDTO, Zaposlenik>();
            CreateMap<ZaposlenikUpdateDTO, Zaposlenik>();
        }
    }
}
