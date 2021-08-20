using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Repositories
{
    public interface IBookRepo
    {
        Task<IEnumerable<Knjiga>> GetBooksAsync(string sort, string q, int? page_index, int? page_size);
        Task<Knjiga> AddBookAsync(Knjiga knjiga);
        Task<bool> UpdateBookAsync(int id, Knjiga knjiga);
        Task<Knjiga> GetBookByIdAsync(int id);
        Task<bool> DeleteBook(int id);
        Task<int> GetBooksSizeAsync();
    }
}
