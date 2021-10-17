using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Data.Models.DTOs.Zaposlenik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IZaposlenikService
    {
        Task<IEnumerable<ZaposlenikReadDTO>> GetZaposlenikeAsync(string sort, string q, int? page_index, int? page_size);
        Task<ZaposlenikReadDTO> AddZaposlenikAsync(ZaposlenikCreateDTO zaposlenikCreateDTO);
        Task<bool> UpdateZaposlenikAsync(int id, ZaposlenikUpdateDTO knjiga);
        Task<ZaposlenikReadDTO> GetZaposlenikByIdAsync(int id);
        Task<ZaposlenikReadDTO> GetZaposlenikByFirebaseIdAsync(string firebaseId);
        Task<int> GetZaposlenikSizeAsync();
    }
}
