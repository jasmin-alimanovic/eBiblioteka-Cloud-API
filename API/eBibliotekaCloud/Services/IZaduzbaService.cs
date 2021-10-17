using eBibliotekaCloud.Data.Models.DTOs.Zaduzba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IZaduzbaService
    {
        Task<IEnumerable<ZaduzbaReadDTO>> GetZaduzbeAsync(string sort, string q, int? page_index, int? page_size);
        Task<ZaduzbaReadDTO> AddZaduzbaAsync(ZaduzbaCreateDTO ZaduzbaCreateDTO);
        Task<bool> UpdateZaduzbaAsync(int id, ZaduzbaUpdateDTO knjiga);
        Task<ZaduzbaReadDTO> GetZaduzbaByIdAsync(int id);
        Task<int> GetZaduzbaSizeAsync();
        IQueryable<object> GetZaduzbeCountByDate(int days);
    }
}
