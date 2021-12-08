using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<KnjigaUpdateDTO, Knjiga>();
            CreateMap<KnjigaCreateDto, Knjiga>();
            CreateMap<KnjigaReadDTO, Knjiga>();
            CreateMap<Knjiga, KnjigaReadDTO>();
        }
    }
}
