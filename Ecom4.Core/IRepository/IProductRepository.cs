using Ecom4.Core.Entities.Product;
using Ecom4.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.IRepository
{
    public interface IProductRepository:IGenricRepository<Product>
    {
        Task<Pagination<Product>> GetAllProductsWithDetailsAsync(QueryProductParams prams);
        Task<Product> GetProductByIdWithDetailsAsync(Guid id);

    }
}
