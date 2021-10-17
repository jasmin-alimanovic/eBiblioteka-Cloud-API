using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.Kartica;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Services;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/kartice")]
    [ApiController]
    public class KarticaController : ControllerBase
    {
        private readonly IKarticaService _service;

        public KarticaController(IKarticaService service)
        {
            _service = service;
        }

       

        // GET: api/kartice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KarticaReadDTO>> GetKartica(int id)
        {
            var kartica = await _service.GetKarticaByIdAsync(id);

            if (kartica == null)
            {
                return NotFound();
            }

            return Ok(kartica);
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateKartica(int id, KarticaCreateDTO Kartica)
        {
            var isUpdated = await _service.UpdateKarticaAsync(id, Kartica);
            if (!isUpdated)
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-Kartica")]
        public async Task<ActionResult<Knjiga>> AddKartica(KarticaCreateDTO KarticaCreateDTO)
        {
            var knjiga = await _service.AddKarticaAsync(KarticaCreateDTO);
            return CreatedAtAction(nameof(GetKartica), new { id = knjiga.Id }, knjiga);
        }

       
    }
}
