
using AutoMapper;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.Zaposlenik;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services.Implementation
{
    public class ZaposlenikService : IZaposlenikService
    {

        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public ZaposlenikService(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ZaposlenikReadDTO> AddZaposlenikAsync(ZaposlenikCreateDTO ZaposlenikCreateDTO)
        {
            var korisnik = _mapper.Map<Zaposlenik>(ZaposlenikCreateDTO);
            await _context.Zaposlenci.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            return _mapper.Map<ZaposlenikReadDTO>(korisnik);
        }


        public async Task<ZaposlenikReadDTO> GetZaposlenikByFirebaseIdAsync(string firebaseId)
        {
            var ZaposlenikDb = await _context.Zaposlenci
                .Include(z => z.Uloga)
                .FirstOrDefaultAsync(k => k.FirebaseId.Equals(firebaseId));
            return _mapper.Map<ZaposlenikReadDTO>(ZaposlenikDb);
        }

        public async Task<ZaposlenikReadDTO> GetZaposlenikByIdAsync(int id)
        {
            var ZaposlenikDb = await _context.Zaposlenci
                .Include(z=>z.Uloga)
                .FirstOrDefaultAsync(k => k.Id == id);
            return _mapper.Map<ZaposlenikReadDTO>(ZaposlenikDb);
        }

        public async Task<IEnumerable<ZaposlenikReadDTO>> GetZaposlenikeAsync(string sort, string q, int? page_index, int? page_size)
        {
            var Zaposleniks = await _context.Zaposlenci
                .Include(z=>z.Uloga)
                .ToListAsync();

            //filtriranje knjiga
            if (!string.IsNullOrEmpty(q) && Zaposleniks != null)
            {
                Zaposleniks = Zaposleniks.Where(b => b.Ime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Prezime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Email.Contains(q, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //sortiranje korisnika
            if (!string.IsNullOrEmpty(sort) && Zaposleniks != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        Zaposleniks = Zaposleniks.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        Zaposleniks = Zaposleniks.OrderBy(b => b.Id).ToList();
                        break;
                    case "ime":
                        Zaposleniks = Zaposleniks.OrderBy(b => b.Ime).ToList();
                        break;
                    case "ime_desc":
                        Zaposleniks = Zaposleniks.OrderByDescending(b => b.Ime).ToList();
                        break;
                    case "email":
                        Zaposleniks = Zaposleniks.OrderBy(b => b.Email).ToList();
                        break;
                    case "email_desc":
                        Zaposleniks = Zaposleniks.OrderByDescending(b => b.Email).ToList();
                        break;
                    case "prezime":
                        Zaposleniks = Zaposleniks.OrderBy(b => b.Prezime).ToList();
                        break;
                    case "prezime_desc":
                        Zaposleniks = Zaposleniks.OrderByDescending(b => b.Prezime).ToList();
                        break;

                }
            }
            int count = Zaposleniks.Count;
            Zaposleniks = PaginatedList<Zaposlenik>.Create(Zaposleniks.AsQueryable(), page_index ?? 1, page_size ?? 5);

            return _mapper.Map<IEnumerable<ZaposlenikReadDTO>>(Zaposleniks);
        }

        public async Task<int> GetZaposlenikSizeAsync()
        {
            return await _context.Zaposlenci.CountAsync();
        }

        public async Task<bool> UpdateZaposlenikAsync(int id, ZaposlenikUpdateDTO korisnik)
        {
            var ZaposlenikDb = await _context.Zaposlenci.Where(k=>k.Id==id).SingleOrDefaultAsync();
            var Zaposlenik = _mapper.Map<Zaposlenik>(korisnik);
            if(ZaposlenikDb == null)
            {
                return false;
            }
            ZaposlenikDb.Ime = Zaposlenik.Ime;
            ZaposlenikDb.Prezime = Zaposlenik.Prezime;
            ZaposlenikDb.FirebaseId = Zaposlenik.FirebaseId;
            ZaposlenikDb.Telefon = Zaposlenik.Telefon;
            ZaposlenikDb.UlogaId = Zaposlenik.UlogaId;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
