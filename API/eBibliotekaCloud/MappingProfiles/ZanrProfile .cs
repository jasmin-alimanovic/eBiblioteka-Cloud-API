using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Zanr;
using eBibliotekaCloud.Models;

namespace eBibliotekaCloud.MappingProfiles
{
    public class ZanrProfile:Profile
    {
        public ZanrProfile()
        {
            CreateMap<Zanr, ZanrReadDTO>();
            CreateMap<ZanrReadDTO, Zanr>();
        }
    }
}
