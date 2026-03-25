using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.Entities.Product
{
    public class Product
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string? Name { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();


    }
}
