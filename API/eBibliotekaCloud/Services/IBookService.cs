using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IBookService
    {
        Task<IEnumerable<KnjigaReadDTO>> GetBooksAsync(string sort, string q, int? page_index, int? page_size);
        Task<KnjigaReadDTO> AddBookAsync(KnjigaCreateDto knjigaCreateDTO);
        Task<bool> UpdateBookAsync(int id, KnjigaUpdateDTO knjiga);
        Task<KnjigaReadDTO> GetBookByIdAsync(int id);
        Task<bool> DeleteBookAsync(int id);
        Task<int> GetBooksSizeAsync();
    }
}
