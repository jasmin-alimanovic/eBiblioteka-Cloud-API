
using AutoMapper;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.Izdavac;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services.Implementation
{
    public class IzdavacService : IIzdavacService
    {

        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public IzdavacService(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IzdavacReadDTO> AddIzdavacAsync(IzdavacCreateDTO IzdavacCreateDTO)
        {
            var korisnik = _mapper.Map<Izdavac>(IzdavacCreateDTO);
            await _context.Izdavaci.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            return _mapper.Map<IzdavacReadDTO>(korisnik);
        }


       

        public async Task<IzdavacReadDTO> GetIzdavacByIdAsync(int id)
        {
            var IzdavacDb = await _context.Izdavaci
                .FirstOrDefaultAsync(k => k.Id == id);
            return _mapper.Map<IzdavacReadDTO>(IzdavacDb);
        }

        public async Task<IEnumerable<IzdavacReadDTO>> GetIzdavaceAsync(string sort, string q, int? page_index, int? page_size)
        {
            var Izdavacs = await _context.Izdavaci
                .ToListAsync();

            //filtriranje knjiga
            if (!string.IsNullOrEmpty(q) && Izdavacs != null)
            {
                Izdavacs = Izdavacs.Where(b => b.Naziv.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Sjediste.Contains(q, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //sortiranje korisnika
            if (!string.IsNullOrEmpty(sort) && Izdavacs != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        Izdavacs = Izdavacs.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        Izdavacs = Izdavacs.OrderBy(b => b.Id).ToList();
                        break;
                    case "Naziv":
                        Izdavacs = Izdavacs.OrderBy(b => b.Naziv).ToList();
                        break;
                    case "Naziv_desc":
                        Izdavacs = Izdavacs.OrderByDescending(b => b.Naziv).ToList();
                        break;
                    case "sjediste":
                        Izdavacs = Izdavacs.OrderBy(b => b.Sjediste).ToList();
                        break;
                    case "sjediste_desc":
                        Izdavacs = Izdavacs.OrderByDescending(b => b.Sjediste).ToList();
                        break;
                }
            }
            int count = Izdavacs.Count;
            Izdavacs = PaginatedList<Izdavac>.Create(Izdavacs.AsQueryable(), page_index ?? 1, page_size ?? 5);

            return _mapper.Map<IEnumerable<IzdavacReadDTO>>(Izdavacs);
        }

        public async Task<int> GetIzdavacSizeAsync()
        {
            return await _context.Korisnici.CountAsync();
        }

        public async Task<bool> UpdateIzdavacAsync(int id, IzdavacCreateDTO korisnik)
        {
            var IzdavacDb = await _context.Izdavaci.Where(k=>k.Id==id).SingleOrDefaultAsync();
            var Izdavac = _mapper.Map<Izdavac>(korisnik);
            if(IzdavacDb == null)
            {
                return false;
            }
            IzdavacDb.Naziv = Izdavac.Naziv;
            IzdavacDb.Sjediste = Izdavac.Sjediste;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
