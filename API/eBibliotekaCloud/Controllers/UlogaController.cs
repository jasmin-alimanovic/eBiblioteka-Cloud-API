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
using eBibliotekaCloud.Data.Models.DTOs.Uloga;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/uloge")]
    [ApiController]
    public class UlogaController : ControllerBase
    {
        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public UlogaController(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Uloga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uloga>>> GetUloge()
        {
            return await _context.Uloge.ToListAsync();
        }

        // GET: api/Uloga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uloga>> GetUloga(int id)
        {
            var uloga = await _context.Uloge.FindAsync(id);

            if (uloga == null)
            {
                return NotFound();
            }

            return uloga;
        }

        // PUT: api/Uloga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUloga(int id, UlogaCreateDTO uloga)
        {
            var ulogaDb = await _context.Uloge.Where(u => u.Id == id).SingleOrDefaultAsync();
            if(ulogaDb == null)
            {
                return NotFound();
            }

            ulogaDb.Naziv = uloga.Naziv;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UlogaExists(id))
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

        // POST: api/Uloga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uloga>> PostUloga(UlogaCreateDTO ulogaCreate)
        {
            var uloga = _mapper.Map<Uloga>(ulogaCreate);
            _context.Uloge.Add(uloga);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException )
            {

                return Conflict();
            }
            

            return CreatedAtAction("GetUloga", new { id = uloga.Id }, uloga);
        }

        

        private bool UlogaExists(int id)
        {
            return _context.Uloge.Any(e => e.Id == id);
        }
    }
}
