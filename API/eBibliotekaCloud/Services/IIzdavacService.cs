using eBibliotekaCloud.Data.Models.DTOs.Izdavac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IIzdavacService
    {
        Task<IEnumerable<IzdavacReadDTO>> GetIzdavaceAsync(string sort, string q, int? page_index, int? page_size);
        Task<IzdavacReadDTO> AddIzdavacAsync(IzdavacCreateDTO IzdavacCreateDTO);
        Task<bool> UpdateIzdavacAsync(int id, IzdavacCreateDTO knjiga);
        Task<IzdavacReadDTO> GetIzdavacByIdAsync(int id);
        Task<int> GetIzdavacSizeAsync();
    }
}
