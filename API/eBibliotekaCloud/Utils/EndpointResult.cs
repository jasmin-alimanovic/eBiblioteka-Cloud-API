using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBibliotekaCloud.Utils
{
    public class EndpointResult<T>
    {
        public int Count { get; set; }
        public string Previous { get; set; }

        public string Next { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
