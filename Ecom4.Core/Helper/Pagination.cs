using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.Helper
{
    public class Pagination<T>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public int totalItems { get; set; }
        public IReadOnlyList<T> Items { get; set; }

        
    }
}
