using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Repositories
{
    public interface IBookRepo
    {
        Task<IEnumerable<Knjiga>> GetBooksAsync();
        Task<Knjiga> AddBookAsync(Knjiga knjiga);
        Task<bool> UpdateBookAsync(int id, Knjiga knjiga);
    }
}
