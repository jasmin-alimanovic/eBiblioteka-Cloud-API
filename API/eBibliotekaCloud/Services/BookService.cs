using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBibliotekaCloud.Repositories;

namespace eBibliotekaCloud.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _repo;
        public BookService(IBookRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Knjiga>> GetBooksAsync()
        {
            var result = await _repo.GetBooksAsync();
            return result;
        }
    }
}
