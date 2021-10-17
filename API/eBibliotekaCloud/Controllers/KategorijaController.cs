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
using eBibliotekaCloud.Data.Models.DTOs.Kategorija;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BibliotekaContext _context;

        public KategorijaController(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Kategorija
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KategorijaReadDTO>>> GetKategorije()
        {
            return Ok(_mapper.Map<IEnumerable<KategorijaReadDTO>>(await _context.Kategorije.OrderByDescending(k=>k.Id).ToListAsync()));
        }

        // GET: api/Kategorija/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KategorijaReadDTO>> GetKategorija(int id)
        {
            var kategorija = _mapper.Map<KategorijaReadDTO>(await _context.Kategorije.FindAsync(id));

            if (kategorija == null)
            {
                return NotFound();
            }

            return kategorija;
        }

        // PUT: api/Kategorija/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategorija(int id, KategorijaCreateDTO kategorija)
        {
            var result = await _context.Kategorije.Where(k => k.Id == id).SingleOrDefaultAsync();
            if(result == null)
            {
                return NotFound();
            }

            result.Naziv = kategorija.Naziv;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorijaExists(id))
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

        // POST: api/Kategorija
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategorija>> PostKategorija(KategorijaCreateDTO kategorija)
        {
            var kat = _mapper.Map<Kategorija>(kategorija);
            _context.Kategorije.Add(kat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategorija", new { id = kat.Id }, kat);
        }

        // DELETE: api/Kategorija/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategorija(int id)
        {
            var kategorija = await _context.Kategorije.FindAsync(id);
            if (kategorija == null)
            {
                return NotFound();
            }

            _context.Kategorije.Remove(kategorija);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategorijaExists(int id)
        {
            return _context.Kategorije.Any(e => e.Id == id);
        }
    }
}
