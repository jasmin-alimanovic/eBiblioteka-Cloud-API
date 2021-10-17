using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models;
using eBibliotekaCloud.Data.Models.DTOs.KnjigaZanr;
using AutoMapper;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnjigaZanrController : ControllerBase
    {
        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public KnjigaZanrController(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        // POST: api/KnjigaZanr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KnjigaZanr>> PostKnjigaZanr(KnjigaZanrCreateDTO knjigaZanr)
        {
            var kz = _mapper.Map<KnjigaZanr>(knjigaZanr);
            _context.KnjigaZanr.Add(kz);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KnjigaZanrExists(knjigaZanr.KnjigaId, knjigaZanr.ZanrId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/KnjigaZanr/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnjigaZanr(int id)
        {
            var knjigaZanr = await _context.KnjigaZanr.FindAsync(id);
            if (knjigaZanr == null)
            {
                return NotFound();
            }

            _context.KnjigaZanr.Remove(knjigaZanr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KnjigaZanrExists(int k_id, int z_id)
        {
            return _context.KnjigaZanr.Any(e => e.KnjigaId == k_id && e.ZanrId==z_id);
        }
    }
}
