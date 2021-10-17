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
using eBibliotekaCloud.Data.Models.DTOs.Zanr;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZanrController : ControllerBase
    {
        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public ZanrController(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Zanr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZanrReadDTO>>> GetZanrovi()
        {
            var result = await _context.Zanrovi.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ZanrReadDTO>>(result));
        }

        // GET: api/Zanr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zanr>> GetZanr(int id)
        {
            var zanr = await _context.Zanrovi.FindAsync(id);

            if (zanr == null)
            {
                return NotFound();
            }

            return zanr;
        }

        // PUT: api/Zanr/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZanr(int id, ZanrCreateDTO zanr)
        {
            var zanrDb = await _context.Zanrovi.Where(z => z.Id == id).SingleOrDefaultAsync();
            zanrDb.Naziv = zanr.Naziv;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZanrExists(id))
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

        // POST: api/Zanr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zanr>> PostZanr(ZanrCreateDTO zanrCreate)
        {
            var zanr = _mapper.Map<Zanr>(zanrCreate);
            _context.Zanrovi.Add(zanr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZanr", new { id = zanr.Id }, zanr);
        }

        private bool ZanrExists(int id)
        {
            return _context.Zanrovi.Any(e => e.Id == id);
        }
    }
}
