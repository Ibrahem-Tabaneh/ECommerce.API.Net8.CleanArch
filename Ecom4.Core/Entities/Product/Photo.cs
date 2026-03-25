using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.Entities.Product
{
    public class Photo
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string? Path { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
