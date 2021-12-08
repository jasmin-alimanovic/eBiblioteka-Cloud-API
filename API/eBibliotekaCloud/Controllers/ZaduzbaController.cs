using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.Zaduzba;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Services;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/zaduzbe")]
    [ApiController]
    public class ZaduzbaController : ControllerBase
    {
        private readonly IZaduzbaService _service;

        public ZaduzbaController(IZaduzbaService service)
        {
            _service = service;
        }

        // GET: api/zaposlenici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZaduzbaReadDTO>>> GetZaduzbe(string sort, string q, int? page_index = 1, int? page_size = 5)
        {
            //get users from db
            var zaduzbe = await _service.GetZaduzbeAsync(sort, q, page_index, page_size);

            //get current uri
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            //variables for next and previous page of pagination
            string prev = null, next = null;
            if (page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }

            int booksSize = await _service.GetZaduzbaSizeAsync();
            int numberOfPages = (int)Math.Ceiling(booksSize / (double)page_size);
            if (page_index < numberOfPages) //if page index is smaller then number of pages then we have next page
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }

            //wrap users in result object
            var result = new EndpointResult<ZaduzbaReadDTO>()
            {
                Data = zaduzbe,
                Count = booksSize,
                Next = next,
                Previous = prev
            };

            return Ok(result);
        }

        // GET: api/zaposlenici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Knjiga>> GetZaduzba(int id)
        {
            var user = await _service.GetZaduzbaByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("group-by-date")]
        public ActionResult GetZaduzbeCountByDate(int days = 7)
        {
            try
            {
                var count = _service.GetZaduzbeCountByDate(days);


                return Ok(count);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateZaduzba(int id, ZaduzbaUpdateDTO Zaduzba)
        {
            var isUpdated = await _service.UpdateZaduzbaAsync(id, Zaduzba);
            if (!isUpdated)
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-Zaduzba")]
        public async Task<ActionResult<ZaduzbaReadDTO>> AddZaduzba(ZaduzbaCreateDTO ZaduzbaCreateDTO)
        {
            var knjiga = await _service.AddZaduzbaAsync(ZaduzbaCreateDTO);
            return CreatedAtAction(nameof(GetZaduzba), new { id = knjiga.Id }, knjiga);
        }

       
    }
}
