
using AutoMapper;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.KnjigaNabavka;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services.Implementation
{
    public class KnjigaNarudzbaService : IKnjigaNarudzbaService
    {

        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public KnjigaNarudzbaService(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<KnjigaNabavkaReadDTO> AddKnjigaNabavkaAsync(KnjigaNabavkaCreateDTO KnjigaNabavkaCreateDTO)
        {
            var korisnik = _mapper.Map<KnjigaNabavka>(KnjigaNabavkaCreateDTO);
            await _context.NabakveKnjiga.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            return _mapper.Map<KnjigaNabavkaReadDTO>(korisnik);
        }


       

        public async Task<KnjigaNabavkaReadDTO> GetKnjigaNabavkaByIdAsync(int id)
        {
            var KnjigaNabavkaDb = await _context.NabakveKnjiga
                .Include(zs => zs.Knjiga)
                .FirstOrDefaultAsync(k => k.Id == id);
            return _mapper.Map<KnjigaNabavkaReadDTO>(KnjigaNabavkaDb);
        }

        public async Task<IEnumerable<KnjigaNabavkaReadDTO>> GetKnjigaNabavkeAsync(string sort, string q, int? page_index, int? page_size)
        {
            var KnjigaNabavkas = await _context.NabakveKnjiga
                .Include(z => z.Knjiga)
                .ToListAsync();

            //filtriranje nabavki

            if(!string.IsNullOrEmpty(q) && KnjigaNabavkas != null)
            {
                KnjigaNabavkas = KnjigaNabavkas.Where(n => n.Sifra.Equals(q) || n.Knjiga.Naziv.Contains(q, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //sortiranje nabavki
            if (!string.IsNullOrEmpty(sort) && KnjigaNabavkas != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        KnjigaNabavkas = KnjigaNabavkas.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        KnjigaNabavkas = KnjigaNabavkas.OrderBy(b => b.Id).ToList();
                        break;
                    case "sifra":
                        KnjigaNabavkas = KnjigaNabavkas.OrderBy(b => b.Sifra).ToList();
                        break;
                    case "sifra_desc":
                        KnjigaNabavkas = KnjigaNabavkas.OrderByDescending(b => b.Sifra).ToList();
                        break;
                }
            }
            int count = KnjigaNabavkas.Count;
            KnjigaNabavkas = PaginatedList<KnjigaNabavka>.Create(KnjigaNabavkas.AsQueryable(), page_index ?? 1, page_size ?? 5);

            return _mapper.Map<IEnumerable<KnjigaNabavkaReadDTO>>(KnjigaNabavkas);
        }

        public async Task<int> GetKnjigaNabavkaSizeAsync()
        {
            return await _context.NabakveKnjiga.CountAsync();
        }

        public async Task<bool> UpdateKnjigaNabavkaAsync(int id, KnjigaNabavkaCreateDTO KnjigaNabavka)
        {
            var KnjigaNabavkaDb = await _context.NabakveKnjiga.Where(k=>k.Id==id).SingleOrDefaultAsync();
            if(KnjigaNabavkaDb == null)
            {
                return false;
            }
            KnjigaNabavkaDb.Kolicina = KnjigaNabavka.Kolicina;
            KnjigaNabavkaDb.Sifra = KnjigaNabavka.Sifra;
            KnjigaNabavkaDb.KnjigaId = KnjigaNabavka.KnjigaId;
            KnjigaNabavkaDb.DatumNabavke = KnjigaNabavka.DatumNabavke;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
