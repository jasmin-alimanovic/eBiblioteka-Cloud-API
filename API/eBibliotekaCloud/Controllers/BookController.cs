using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Services;
using eBibliotekaCloud.Data.Models.DTOs.Knjiga;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Data.Models;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly BibliotekaContext _context;

        public BookController(IBookService service, BibliotekaContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knjiga>>> GetKnjige(string sort, string q, int? page_index=1, int? page_size=5)
        {
            var books= await _service.GetBooksAsync(sort, q, page_index, page_size);
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            string prev = null, next = null;
            if(page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }
            int booksSize = await _service.GetBooksSizeAsync();
            if (page_index < (int)Math.Ceiling(booksSize / (double)page_size))
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }
            var result = new EndpointResult<KnjigaReadDTO>()
            {
                Data = books,
                Count = booksSize,
                Next = next,
                Previous = prev
            };
            //Console.WriteLine($"{result.Data.FirstOrDefault(d=>d.Id==4).Zanrovi}")

            /*foreach (var item in result.Data.FirstOrDefault(d => d.Id == 4).Zanrovi)
            {
                Console.WriteLine(item.Zanr?.ToString());
            }*/
            return Ok(result);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Knjiga>> GetKnjiga(int id)
        {
            var knjiga = await _service.GetBookByIdAsync(id);

            if (knjiga == null)
            {
                return NotFound();
            }

            return Ok(knjiga);
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutKnjiga(int id, KnjigaUpdateDTO knjiga)
        {
            
            if(!(await _service.UpdateBookAsync(id, knjiga)))
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-book")]
        public async Task<ActionResult<Knjiga>> PostKnjiga(KnjigaCreateDto knjigaCreateDTO)
        {
            var knjiga = await _service.AddBookAsync(knjigaCreateDTO);
            return CreatedAtAction(nameof(GetKnjiga), new { id = knjiga.Id }, knjiga);
        }

        // DELETE: api/Book/5
        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteKnjiga(int id)
        {
            if (!(await _service.DeleteBookAsync(id)))
                return BadRequest();
            return NoContent();
        }

        /* private bool KnjigaExists(int id)
        {
            return _context.Knjige.Any(e => e.Id == id);
        } */
    }
}
