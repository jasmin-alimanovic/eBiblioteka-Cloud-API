using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.Autor;
using AutoMapper;

namespace eBibliotekaCloud.Controllers
{
    [Route("api/autori")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public AutorController(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorReadDTO>>> GetAutori()
        {
            var result = await _context.Autori.OrderByDescending(a=>a.Id).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<AutorReadDTO>>(result));
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _context.Autori.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AutorReadDTO>(autor));
        }

        // PUT: api/Autor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, AutorUpdateDTO autor)
        {

            var autorDb = await _context.Autori.Where(a => a.Id == id).SingleOrDefaultAsync();
            if(autorDb == null)
            {
                return NotFound();
            }

            autorDb.Ime = autor.Ime;
            autorDb.Prezime = autor.Prezime;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Autor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(AutorCreateDTO autor)
        {
            var autorDTO = _mapper.Map<Autor>(autor);
            _context.Autori.Add(autorDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autorDTO.Id }, autor);
        }

        
    }
}
