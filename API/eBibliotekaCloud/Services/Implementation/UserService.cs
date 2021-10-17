
using AutoMapper;
using eBibliotekaCloud.Data;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;


namespace eBibliotekaCloud.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly BibliotekaContext _context;
        private readonly IMapper _mapper;

        public UserService()
        {
        }

        public UserService(BibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }


        public async Task<KorisnikReadDTO> AddUserAsync(KorisnikCreateDTO korisnikCreateDTO)
        {
            try
            {
                var korisnik = _mapper.Map<Korisnik>(korisnikCreateDTO);
                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();
                return _mapper.Map<KorisnikReadDTO>(korisnik);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<KorisnikReadDTO>> GetNewUsersAsync(string sort, string q, int? page_index, int? page_size)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var todaysDate = DateTime.UtcNow.AddHours(2);
            var users = await _context.Korisnici
                .Include(k => k.Kartice)
                .Where(k => k.DatumUclanjenja.AddHours(24) > todaysDate)
                .ToListAsync();

            //filtriranje knjiga
            if (!string.IsNullOrEmpty(q) && users != null)
            {
                users = users.Where(b => b.Ime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Prezime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Email.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Id.ToString().Contains(q,StringComparison.CurrentCultureIgnoreCase)
                ).ToList();
                
            }
            //sortiranje korisnika
            if (!string.IsNullOrEmpty(sort) && users != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        users = users.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        users = users.OrderBy(b => b.Id).ToList();
                        break;
                    case "ime":
                        users = users.OrderBy(b => b.Ime).ToList();
                        break;
                    case "ime_desc":
                        users = users.OrderByDescending(b => b.Ime).ToList();
                        break;
                    case "email":
                        users = users.OrderBy(b => b.Email).ToList();
                        break;
                    case "email_desc":
                        users = users.OrderByDescending(b => b.Email).ToList();
                        break;
                    case "prezime":
                        users = users.OrderBy(b => b.Prezime).ToList();
                        break;
                    case "prezime_desc":
                        users = users.OrderByDescending(b => b.Prezime).ToList();
                        break;

                }
            }
            int count = users.Count;
            users = PaginatedList<Korisnik>.Create(users.AsQueryable(), page_index ?? 1, page_size ?? 5);

            return _mapper.Map<IEnumerable<KorisnikReadDTO>>(users);
        }

        public async Task<int> GetNewUsersCountAsync()
        {
            var todaysDate = DateTime.UtcNow.AddHours(2);
            var count = await _context.Korisnici
                .Where(k => k.DatumUclanjenja.AddHours(24) > todaysDate)
                .CountAsync();
            return count;
        }

        public async Task<KorisnikReadDTO> GetUserByEmailAsync(string email)
        {
            var user = await _context.Korisnici.Where(k => k.Email.Equals(email))
                .Include(u=>u.Zaduzbe)
                .ThenInclude(z => z.Knjiga)
                .ThenInclude(k=>k.Autor)
                .FirstOrDefaultAsync();
            return _mapper.Map<KorisnikReadDTO>(user);
        }

        public async Task<KorisnikReadDTO> GetUserByFirebaseIdAsync(string firebaseId)
        {
            var userDb = await _context.Korisnici
                .Include(u => u.Zaduzbe)
                .ThenInclude(z => z.Knjiga)
                .ThenInclude(k => k.Autor)
                .Include(u => u.Zaduzbe)
                .ThenInclude(z => z.Knjiga)
                .ThenInclude(k => k.Izdavac)
                .Include(u => u.Zaduzbe)
                .ThenInclude(z => z.Knjiga)
                .ThenInclude(k => k.Jezik)
                .Include(u => u.Zaduzbe)
                .ThenInclude(z => z.Knjiga)
                .ThenInclude(k => k.Kategorija)
                .FirstOrDefaultAsync(k => k.FirebaseId.Equals(firebaseId));
            return _mapper.Map<KorisnikReadDTO>(userDb);
        }

        public async Task<KorisnikReadDTO> GetUserByIdAsync(int id)
        {
            var userDb = await _context.Korisnici.Include(u => u.Zaduzbe).ThenInclude(z => z.Knjiga).FirstOrDefaultAsync(k => k.Id == id);
            return _mapper.Map<KorisnikReadDTO>(userDb);
        }

        public async Task<IEnumerable<KorisnikReadDTO>> GetUsersAsync(string sort, string q, int? page_index, int? page_size)
        {
            var users = await _context.Korisnici
                .Include(u => u.Zaduzbe).ThenInclude(z => z.Knjiga)
                .ToListAsync();

            //filtriranje knjiga
            if (!string.IsNullOrEmpty(q) && users != null)
            {
                users = users.Where(b => b.Ime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Prezime.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Email.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.KorisnickoIme.Contains(q, StringComparison.CurrentCultureIgnoreCase)
                || b.Id.ToString().Contains(q, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //sortiranje korisnika
            if (!string.IsNullOrEmpty(sort) && users != null)
            {
                switch (sort)
                {
                    case "id_desc":
                        users = users.OrderByDescending(b => b.Id).ToList();
                        break;
                    case "id":
                        users = users.OrderBy(b => b.Id).ToList();
                        break;
                    case "ime":
                        users = users.OrderBy(b => b.Ime).ToList();
                        break;
                    case "ime_desc":
                        users = users.OrderByDescending(b => b.Ime).ToList();
                        break;
                    case "email":
                        users = users.OrderBy(b => b.Email).ToList();
                        break;
                    case "email_desc":
                        users = users.OrderByDescending(b => b.Email).ToList();
                        break;
                    case "prezime":
                        users = users.OrderBy(b => b.Prezime).ToList();
                        break;
                    case "prezime_desc":
                        users = users.OrderByDescending(b => b.Prezime).ToList();
                        break;
                    case "datum":
                        users = users.OrderBy(b => b.DatumUclanjenja).ToList();
                        break;
                    case "datum_desc":
                        users = users.OrderByDescending(b => b.DatumUclanjenja).ToList();
                        break;

                }
            }
            int count = users.Count;
            users = PaginatedList<Korisnik>.Create(users.AsQueryable(), page_index ?? 1, page_size ?? 5);

            return _mapper.Map<IEnumerable<KorisnikReadDTO>>(users);
        }

        public IQueryable<object> GetUsersCountByDate(int days = 7)
        {
            var date = DateTime.Now.AddDays(-days).Date;

            var result = _context.Korisnici.
                Where(k => k.DatumUclanjenja > date).
                GroupBy(k => k.DatumUclanjenja.Date).
                Select(k => new
                {
                    k.Key,
                    Count = k.Count()
                }
                );


            /*var result = from k in _context.Korisnici
                         where k.DatumUclanjenja > date
                         group k by k.DatumUclanjenja.Date
                         into size
                         select new
                         {
                             size.Key,
                             Count = size.Count()
                             
                         };*/
                         
            return result;
        }

        public async Task<int> GetUserSizeAsync()
        {
            return await _context.Korisnici.CountAsync();
        }

        public async Task<bool> UpdateUserAsync(int id, KorisnikUpdateDTO korisnik)
        {
            var userDb = await _context.Korisnici.Where(k=>k.Id==id).SingleOrDefaultAsync();
            var user = _mapper.Map<Korisnik>(korisnik);
            if(userDb == null)
            {
                return false;
            }
            userDb.Adresa = user.Adresa;
            userDb.Ime = user.Ime;
            userDb.Prezime = user.Prezime;
            userDb.FirebaseId = user.FirebaseId;
            userDb.KorisnickoIme = user.KorisnickoIme;
            userDb.Telefon = user.Telefon;

            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
