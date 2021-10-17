using eBibliotekaCloud.Data.Models.DTOs.Kartica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IKarticaService
    {
        
        Task<KarticaReadDTO> AddKarticaAsync(KarticaCreateDTO KarticaCreateDTO);
        Task<bool> UpdateKarticaAsync(int id, KarticaCreateDTO knjiga);
        Task<KarticaReadDTO> GetKarticaByIdAsync(int id);
        Task<KarticaReadDTO> GetKarticaByUserIdAsync(int id);
        Task<int> GetKarticaSizeAsync();
    }
}
