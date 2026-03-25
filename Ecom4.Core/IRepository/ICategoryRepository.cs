using Ecom4.Core.Entities.Product;
using Ecom4.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.IRepository
{
    public interface ICategoryRepository:IGenricRepository<Category>
    {
        //future methods
        public Task<Pagination<Category>> GetAllPaginationAsync(QueryCategoryParams prams);

    }
}
