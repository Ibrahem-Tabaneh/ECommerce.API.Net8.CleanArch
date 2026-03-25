using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.Helper
{
    public class QueryProductParams
    {
       public string? sort { get; set; }
       public string? search {  get; set; }
       public Guid? categoryid { get; set; }
       public int pagenumber { get; set; } = 1;
        public int pagesize { get; set; } = 6;
    }
}
