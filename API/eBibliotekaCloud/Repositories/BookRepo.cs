using eBibliotekaCloud.Data;
using eBibliotekaCloud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Repositories
{
    public class BookRepo : IBookRepo
    {

        private readonly BibliotekaContext _context;
        public BookRepo(BibliotekaContext context)
        {
            _context = context;
        }
        public Task<Knjiga> AddBookAsync(Knjiga knjiga)
        {
            throw new NotImplementedException();
            
        }

        public async Task<IEnumerable<Knjiga>> GetBooksAsync()
        {
            var books = await _context.Knjige
                   .Include(b => b.Autor)
                   .Include(b => b.Autor)
                   .Include(b => b.Autor)
                   .Include(b => b.Zanrovi)
                   .ToListAsync();
            return books;
        }

        public Task<bool> UpdateBookAsync(int id, Knjiga knjiga)
        {
            throw new NotImplementedException();
        }
    }
}
