using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.KnjigaNabavka;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Services;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/nabavke")]
    [ApiController]
    public class KnjigaNabavkaController : ControllerBase
    {
        private readonly IKnjigaNarudzbaService _service;

        public KnjigaNabavkaController(IKnjigaNarudzbaService service)
        {
            _service = service;
        }

        // GET: api/zaposlenici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KnjigaNabavka>>> GetNabavke(string sort, string q, int? page_index = 1, int? page_size = 5)
        {
            //get users from db
            var users = await _service.GetKnjigaNabavkeAsync(sort, q, page_index, page_size);

            //get current uri
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            //variables for next and previous page of pagination
            string prev = null, next = null;
            if (page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }

            int booksSize = await _service.GetKnjigaNabavkaSizeAsync();
            int numberOfPages = (int)Math.Ceiling(booksSize / (double)page_size);
            if (page_index < numberOfPages) //if page index is smaller then number of pages then we have next page
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }

            //wrap users in result object
            var result = new EndpointResult<KnjigaNabavkaReadDTO>()
            {
                Data = users,
                Count = booksSize,
                Next = next,
                Previous = prev
            };

            return Ok(result);
        }

        // GET: api/zaposlenici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Knjiga>> GetKnjigaNabavka(int id)
        {
            var user = await _service.GetKnjigaNabavkaByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateKnjigaNabavka(int id, KnjigaNabavkaCreateDTO KnjigaNabavka)
        {
            var isUpdated = await _service.UpdateKnjigaNabavkaAsync(id, KnjigaNabavka);
            if (!isUpdated)
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-KnjigaNabavka")]
        public async Task<ActionResult<Knjiga>> AddKnjigaNabavka(KnjigaNabavkaCreateDTO KnjigaNabavkaCreateDTO)
        {
            var knjiga = await _service.AddKnjigaNabavkaAsync(KnjigaNabavkaCreateDTO);
            return CreatedAtAction(nameof(GetKnjigaNabavka), new { id = knjiga.Id }, knjiga);
        }

       
    }
}
