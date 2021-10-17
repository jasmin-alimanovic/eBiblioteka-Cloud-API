using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.Izdavac;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Services;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/izdavaci")]
    [ApiController]
    public class IzdavacController : ControllerBase
    {
        private readonly IIzdavacService _service;

        public IzdavacController(IIzdavacService service)
        {
            _service = service;
        }

        // GET: api/zaposlenici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Izdavac>>> GetIzdavace(string sort, string q, int? page_index = 1, int? page_size = 5)
        {
            //get users from db
            var users = await _service.GetIzdavaceAsync(sort, q, page_index, page_size);

            //get current uri
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            //variables for next and previous page of pagination
            string prev = null, next = null;
            if (page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }

            int booksSize = await _service.GetIzdavacSizeAsync();
            int numberOfPages = (int)Math.Ceiling(booksSize / (double)page_size);
            if (page_index < numberOfPages) //if page index is smaller then number of pages then we have next page
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }

            //wrap users in result object
            var result = new EndpointResult<IzdavacReadDTO>()
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
        public async Task<ActionResult<Knjiga>> GetIzdavac(int id)
        {
            var user = await _service.GetIzdavacByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateIzdavac(int id, IzdavacCreateDTO Izdavac)
        {
            var isUpdated = await _service.UpdateIzdavacAsync(id, Izdavac);
            if (!isUpdated)
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-Izdavac")]
        public async Task<ActionResult<Knjiga>> AddIzdavac(IzdavacCreateDTO IzdavacCreateDTO)
        {
            var knjiga = await _service.AddIzdavacAsync(IzdavacCreateDTO);
            return CreatedAtAction(nameof(GetIzdavac), new { id = knjiga.Id }, knjiga);
        }

       
    }
}
