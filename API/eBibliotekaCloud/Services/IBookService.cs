using eBibliotekaCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Knjiga>> GetBooksAsync();

    }
}
