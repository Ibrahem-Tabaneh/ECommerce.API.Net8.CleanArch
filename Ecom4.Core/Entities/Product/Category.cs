using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.Entities.Product
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
