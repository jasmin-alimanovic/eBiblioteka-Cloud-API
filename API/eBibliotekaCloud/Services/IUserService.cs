using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IUserService
    {
        Task<IEnumerable<KorisnikReadDTO>> GetUsersAsync(string sort, string q, int? page_index, int? page_size);
        Task<KorisnikReadDTO> AddUserAsync(KorisnikCreateDTO korisnikCreateDTO);
        Task<bool> UpdateUserAsync(int id, KorisnikUpdateDTO knjiga);
        Task<KorisnikReadDTO> GetUserByIdAsync(int id);
        Task<KorisnikReadDTO> GetUserByFirebaseIdAsync(string firebaseId);
        Task<KorisnikReadDTO> GetUserByEmailAsync(string email);
        Task<int> GetUserSizeAsync();
        Task<int> GetNewUsersCountAsync();
        Task<IEnumerable<KorisnikReadDTO>> GetNewUsersAsync(string sort, string q, int? page_index, int? page_size);
        IQueryable<object> GetUsersCountByDate(int days);
    }
}
