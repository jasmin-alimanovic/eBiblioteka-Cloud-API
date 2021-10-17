
using AutoMapper;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.Zaduzba;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services.Implementation
{
    public class ZaduzbaService : IZaduzbaService
    {

        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public ZaduzbaService(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ZaduzbaReadDTO> AddZaduzbaAsync(ZaduzbaCreateDTO ZaduzbaCreateDTO)
        {
            var zaduzba = _mapper.Map<Zaduzba>(ZaduzbaCreateDTO);
            await _context.Zaduzbe.AddAsync(zaduzba);
            await _context.SaveChangesAsync();
            return _mapper.Map<ZaduzbaReadDTO>(zaduzba);
        }

        public IQueryable<object> GetZaduzbeCountByDate(int days = 7)
        {
            //var result = await _context.Korisnici.SelectMany(u => u.DatumUclanjenja).GroupBy(k => k.Date).CountAsync();

            var date = DateTime.Now.AddDays(-days);

            var result = from z in _context.Zaduzbe
                         where z.DatumZaduzbe > date
                         group z by z.DatumZaduzbe.Date
                         into size
                         select new
                         {
                             size.Key,
                             Count = size.Count()
                         };

            return result;
        }


        public async Task<ZaduzbaReadDTO> GetZaduzbaByIdAsync(int id)
        {
            var ZaduzbaDb = await _context.Zaduzbe
                .Include(z=>z.Knjiga)
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(k => k.Id == id);
            return _mapper.Map<ZaduzbaReadDTO>(ZaduzbaDb);
        }

        public async Task<IEnumerable<ZaduzbaReadDTO>> GetZaduzbeAsync(string sort, string q, int? page_index, int? page_size)
        {
            var Zaduzbas = await _context.Zaduzbe
                .Include(z=>z.Knjiga)
                .ThenInclude(k=>k.Autor)
                .Include(z => z.Knjiga)
                .ThenInclude(k => k.Kategorija)
                .Include(z => z.Knjiga)
                .ThenInclude(k => k.Jezik)
                .Include(z => z.Knjiga)
                .ThenInclude(k => k.Izdavac)
                .Include(z => z.Knjiga)
                .Include(z=>z.Korisnik)
                .ToListAsync();

            //filtriranje zadužbi
            if(!string.IsNullOrEmpty(q) && Zaduzbas != null)
            {
                Zaduzbas = Zaduzbas
                    .Where(z => z.Id.ToString().Contains(q, StringComparison.CurrentCultureIgnoreCase) 
                    || z.Knjiga.Naziv.Contains(q) 
                    || (z.Korisnik.Ime + " " + z.Korisnik.Prezime).Contains(q, StringComparison.CurrentCultureIgnoreCase) 
                    || z.KorisnikId.ToString().Contains(q, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //sortiranje korisnika
            if (!string.IsNullOrEmpty(sort) && Zaduzbas != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        Zaduzbas = Zaduzbas.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        Zaduzbas = Zaduzbas.OrderBy(b => b.Id).ToList();
                        break;
                    case "datum":
                        Zaduzbas = Zaduzbas.OrderBy(b => b.DatumZaduzbe).ToList();
                        break;
                    case "datum_desc":
                        Zaduzbas = Zaduzbas.OrderByDescending(b => b.DatumZaduzbe).ToList();
                        break;
                    case "status":
                        Zaduzbas = Zaduzbas.OrderBy(b => b.IsZavrsena).ToList();
                        break;
                    case "status_desc":
                        Zaduzbas = Zaduzbas.OrderByDescending(b => b.IsZavrsena).ToList();
                        break;
                    default:
                        break;
                }
            }
            int count = Zaduzbas.Count;
            var Zaduzbe = PaginatedList<Zaduzba>.Create(Zaduzbas.AsQueryable(), page_index ?? 1, page_size ?? 5);
            
            

            return _mapper.Map<IEnumerable<ZaduzbaReadDTO>>(Zaduzbe);
        }

        public async Task<int> GetZaduzbaSizeAsync()
        {
            return await _context.Zaduzbe.CountAsync();
        }

        public async Task<bool> UpdateZaduzbaAsync(int id, ZaduzbaUpdateDTO zaduzba)
        {
            var ZaduzbaDb = await _context.Zaduzbe.Where(k=>k.Id==id).SingleOrDefaultAsync();
            if(ZaduzbaDb == null)
            {
                return false;
            }
            ZaduzbaDb.IsZavrsena = zaduzba.IsZavrsena;
            ZaduzbaDb.DatumVracanja = DateTime.UtcNow.AddHours(2);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
