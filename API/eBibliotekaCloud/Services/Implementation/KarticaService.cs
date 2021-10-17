
using AutoMapper;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.Kartica;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services.Implementation
{
    public class KarticaService : IKarticaService
    {

        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public KarticaService(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<KarticaReadDTO> AddKarticaAsync(KarticaCreateDTO KarticaCreateDTO)
        {
            var korisnik = _mapper.Map<Kartica>(KarticaCreateDTO);
            await _context.Kartice.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            return _mapper.Map<KarticaReadDTO>(korisnik);
        }


       

        public async Task<KarticaReadDTO> GetKarticaByIdAsync(int id)
        {
            var KarticaDb = await _context.Kartice
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(k => k.Id == id);
            return _mapper.Map<KarticaReadDTO>(KarticaDb);
        }

        public async Task<IEnumerable<KarticaReadDTO>> GetKarticeAsync(string sort, string q, int? page_index, int? page_size)
        {
            var Karticas = await _context.Kartice
                .Include(z=>z.Korisnik)
                .ToListAsync();

            

            
            int count = Karticas.Count;
            Karticas = PaginatedList<Kartica>.Create(Karticas.AsQueryable(), page_index ?? 1, page_size ?? 5);

            return _mapper.Map<IEnumerable<KarticaReadDTO>>(Karticas);
        }

        public async Task<int> GetKarticaSizeAsync()
        {
            return await _context.Kartice.CountAsync();
        }

        public async Task<bool> UpdateKarticaAsync(int id, KarticaCreateDTO Kartica)
        {
            var KarticaDb = await _context.Kartice.Where(k=>k.Id==id).SingleOrDefaultAsync();
            if(KarticaDb == null)
            {
                return false;
            }
            KarticaDb.KorisnikId = Kartica.KorisnikId;
            KarticaDb.Vlasnik = Kartica.Vlasnik;
            KarticaDb.DtmIsteka= Kartica.DtmIsteka;
            KarticaDb.CVV = Kartica.CVV;
            KarticaDb.BrojKartice = Kartica.BrojKartice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<KarticaReadDTO> GetKarticaByUserIdAsync(int id)
        {
            var KarticaDb = await _context.Kartice
                .Include(z => z.Korisnik)
                .FirstOrDefaultAsync(k =>k.KorisnikId == id);
            return _mapper.Map<KarticaReadDTO>(KarticaDb);
        }
    }
}
