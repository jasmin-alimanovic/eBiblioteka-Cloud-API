using eBibliotekaCloud.Data;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
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
        public async Task<Knjiga> AddBookAsync(Knjiga knjiga)
        {
            await _context.Knjige.AddAsync(knjiga);
            await _context.SaveChangesAsync();
            return knjiga;
            
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookDb = await GetBookByIdAsync(id);
            bookDb.IsDeleted = true;
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<Knjiga> GetBookByIdAsync(int id)
        {
            return await _context.Knjige
                .Include(b => b.Autor)
                   .Include(b => b.Kategorija)
                   .Include(b => b.Jezik)
                   .Include(b => b.KnjigaZanr)
                   .ThenInclude(kz=>kz.Zanr)
                   .Include(b => b.Izdavac)
                   .Where(b => b.Id == id)
                   .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Knjiga>> GetBooksAsync(string sort, string q, int? page_index, int? page_size)
        {
            var books = await _context.Knjige
                   .Include(b => b.Autor)
                   .Include(b => b.Kategorija)
                   .Include(b => b.Jezik)
                   .Include(b => b.KnjigaZanr)
                   .ThenInclude(kz => kz.Zanr)
                   .Include(b => b.Izdavac)
                   .Where(b=>b.IsDeleted==false)
                   .ToListAsync();


            //filtriranje knjiga
            if(!string.IsNullOrEmpty(q) && books != null)
            {
                books = books.Where(b => b.Naziv.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Autor.Ime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Autor.Prezime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Izdavac.Naziv.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.ISBN.Contains(q, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }


            //sortiranje knjiga
            if(!string.IsNullOrEmpty(sort) && books != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        books = books.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        books = books.OrderBy(b => b.Id).ToList();
                        break;
                    case "naziv":
                        books = books.OrderBy(b => b.Naziv).ToList();
                        break;
                    case "naziv_desc":
                        books = books.OrderByDescending(b => b.Naziv).ToList();
                        break;
                    case "cijena":
                        books = books.OrderBy(b => b.Cijena).ToList();
                        break;
                    case "cijena_desc":
                        books = books.OrderByDescending(b => b.Naziv).ToList();
                        break;
                    case "godina":
                        books = books.OrderBy(b => b.GodinaIzdavanja).ToList();
                        break;
                    case "godina_desc":
                        books = books.OrderByDescending(b => b.GodinaIzdavanja).ToList();
                        break;

                }
            }

            int count = books.Count;
            books = PaginatedList<Knjiga>.Create(books.AsQueryable(), page_index ?? 1, page_size ?? 5);
            
            return books;
        }

        public async Task<int> GetBooksSizeAsync()
        {
            return await _context.Knjige.CountAsync();
        }

        public async Task<bool> UpdateBookAsync(int id, Knjiga knjiga)
        {
            var book = await GetBookByIdAsync(id);
            if(book == null)
            {
                return false;

            }

            //_context.Update(knjiga);
            book.Naziv = knjiga.Naziv;
            book.Cijena = knjiga.Cijena;
            book.Popust = knjiga.Popust;
            book.Dostupno = knjiga.Dostupno;
            book.Ukupno = knjiga.Ukupno;
            book.IzdavacId = knjiga.IzdavacId;
            book.AutorId = knjiga.AutorId;
            book.JezikId = knjiga.JezikId;
            book.KategorijaId = knjiga.KategorijaId;
            book.PdfUrl = knjiga.PdfUrl;
            book.ImageUrl = knjiga.ImageUrl;
            book.KratkiOpis = knjiga.KratkiOpis;
            book.DugiOpis = knjiga.DugiOpis;
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
