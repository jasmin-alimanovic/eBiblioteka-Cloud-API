using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.Zaposlenik;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Services;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/zaposlenici")]
    [ApiController]
    public class ZaposleniciController : ControllerBase
    {
        private readonly IZaposlenikService _service;

        public ZaposleniciController(IZaposlenikService service)
        {
            _service = service;
        }

        // GET: api/zaposlenici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zaposlenik>>> GetZaposlenike(string sort, string q, int? page_index = 1, int? page_size = 5)
        {
            //get users from db
            var users = await _service.GetZaposlenikeAsync(sort, q, page_index, page_size);

            //get current uri
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            //variables for next and previous page of pagination
            string prev = null, next = null;
            if (page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }

            int booksSize = await _service.GetZaposlenikSizeAsync();
            int numberOfPages = (int)Math.Ceiling(booksSize / (double)page_size);
            if (page_index < numberOfPages) //if page index is smaller then number of pages then we have next page
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }

            //wrap users in result object
            var result = new EndpointResult<ZaposlenikReadDTO>()
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
        public async Task<ActionResult<Knjiga>> GetZaposlenik(int id)
        {
            var user = await _service.GetZaposlenikByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/zaposlenici/5
        [HttpGet("fid/{fid}")]
        public async Task<ActionResult<Knjiga>> GetZaposlenikByFirebaseId(string fid)
        {
            var user = await _service.GetZaposlenikByFirebaseIdAsync(fid);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateZaposlenik(int id, ZaposlenikUpdateDTO Zaposlenik)
        {
            var isUpdated = await _service.UpdateZaposlenikAsync(id, Zaposlenik);
            if (!isUpdated)
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-zaposlenik")]
        public async Task<ActionResult<Knjiga>> AddZaposlenik(ZaposlenikCreateDTO ZaposlenikCreateDTO)
        {
            var knjiga = await _service.AddZaposlenikAsync(ZaposlenikCreateDTO);
            return CreatedAtAction(nameof(GetZaposlenik), new { id = knjiga.Id }, knjiga);
        }

       
    }
}
