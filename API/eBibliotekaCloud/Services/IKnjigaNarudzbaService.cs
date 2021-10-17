using eBibliotekaCloud.Data.Models.DTOs.KnjigaNabavka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IKnjigaNarudzbaService
    {
        Task<IEnumerable<KnjigaNabavkaReadDTO>> GetKnjigaNabavkeAsync(string sort, string q, int? page_index, int? page_size);
        Task<KnjigaNabavkaReadDTO> AddKnjigaNabavkaAsync(KnjigaNabavkaCreateDTO KnjigaNabavkaCreateDTO);
        Task<bool> UpdateKnjigaNabavkaAsync(int id, KnjigaNabavkaCreateDTO nabavka);
        Task<KnjigaNabavkaReadDTO> GetKnjigaNabavkaByIdAsync(int id);
        Task<int> GetKnjigaNabavkaSizeAsync();
    }
}
