using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBibliotekaCloud.Repositories;
using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Knjiga;

namespace eBibliotekaCloud.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _repo;
        private readonly IMapper _mapper;
        public BookService(IBookRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<KnjigaReadDTO> AddBookAsync(KnjigaCreateDto knjigaCreateDTO)
        {
            var knjiga = _mapper.Map<Knjiga>(knjigaCreateDTO);
            knjiga.Dostupno = knjigaCreateDTO.Ukupno;
            var result =  await _repo.AddBookAsync(knjiga);
            return _mapper.Map<KnjigaReadDTO>(result);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _repo.DeleteBook(id);
        }

        public async Task<KnjigaReadDTO> GetBookByIdAsync(int id)
        {
            var result = await _repo.GetBookByIdAsync(id);
            return _mapper.Map<KnjigaReadDTO>(result);
        }

        public async Task<IEnumerable<KnjigaReadDTO>> GetBooksAsync(string sort, string q, int? page_index, int? page_size, int? kategorija)
        {
            var result = await _repo.GetBooksAsync(sort, q, page_index, page_size, kategorija);
            return _mapper.Map<IEnumerable<KnjigaReadDTO>>(result) ;
        }

        public async Task<int> GetBooksSizeAsync()
        {
            return await _repo.GetBooksSizeAsync();
        }

        public Task<bool> UpdateBookAsync(int id, KnjigaUpdateDTO knjiga)
        {
            var book = _mapper.Map<Knjiga>(knjiga);
            return _repo.UpdateBookAsync(id, book);
        }
    }
}
