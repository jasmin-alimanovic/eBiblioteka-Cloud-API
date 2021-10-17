using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Models;
using AutoMapper;
using eBibliotekaCloud.Data.Models.DTOs.Jezik;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/jezici")]
    [ApiController]
    public class JezikController : ControllerBase
    {
        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;


        public JezikController(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Jezik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JezikReadDTO>>> GetJezici()
        {
            return Ok(_mapper.Map<IEnumerable<JezikReadDTO>>(await _context.Jezici.OrderByDescending(j=>j.Id).ToListAsync()));
        }

        // GET: api/Jezik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JezikReadDTO>> GetJezik(int id)
        {
            var jezik = await _context.Jezici.FindAsync(id);

            if (jezik == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JezikReadDTO>(jezik)); ;
        }

        // PUT: api/Jezik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJezik(int id, JezikCreateDTO jezik)
        {
            var result = await _context.Jezici.Where(k => k.Id == id).SingleOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }

            result.Naziv = jezik.Naziv;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JezikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Jezik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jezik>> PostJezik(JezikCreateDTO jezik)
        {
            var jezikDb = _mapper.Map<Jezik>(jezik);
            _context.Jezici.Add(jezikDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJezik", new { id = jezikDb.Id }, jezikDb);
        }

        // DELETE: api/Jezik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJezik(int id)
        {
            var jezik = await _context.Jezici.FindAsync(id);
            if (jezik == null)
            {
                return NotFound();
            }

            _context.Jezici.Remove(jezik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JezikExists(int id)
        {
            return _context.Jezici.Any(e => e.Id == id);
        }
    }
}
