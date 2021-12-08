using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Autor;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<Autor, AutorReadDTO>();
            CreateMap<AutorCreateDTO, Autor>();
            CreateMap<AutorUpdateDTO, Autor>();
        }
    }
}
