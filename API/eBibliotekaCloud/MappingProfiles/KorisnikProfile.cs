using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.MappingProfiles
{
    public class KorisnikProfile : Profile
    {
        public KorisnikProfile()
        {
            CreateMap<Korisnik, KorisnikReadDTO>();
            CreateMap<KorisnikCreateDTO, Korisnik>();
            CreateMap<KorisnikUpdateDTO, Korisnik>();
        }
    }
}
