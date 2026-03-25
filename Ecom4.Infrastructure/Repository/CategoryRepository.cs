using Ecom4.Core.Entities.Product;
using Ecom4.Core.Helper;
using Ecom4.Core.IRepository;
using Ecom4.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Infrastructure.Repository
{
    public class CategoryRepository:GenricRepository<Category> ,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<Pagination<Category>> GetAllPaginationAsync(QueryCategoryParams prams)
        {
            var categories = context.Categories
                .AsNoTracking()
                .AsQueryable();

            int totalItems = await categories.CountAsync();

            categories = categories.OrderBy(c => c.Name);

            prams.pagesize = prams.pagesize <= 0 ? 9 : prams.pagesize;
            prams.pagesize = prams.pagesize > 50 ? 50 : prams.pagesize;
            prams.pagenumber = prams.pagenumber <= 0 ? 1 : prams.pagenumber;

            var items = await categories
                .Skip((prams.pagenumber - 1) * prams.pagesize)
                .Take(prams.pagesize)
                .ToListAsync();
            return new Pagination<Category>
            {
                Items = items,
                pageNumber = prams.pagenumber,
                pageSize = prams.pagesize,
                totalItems = totalItems
            };
        }

    }
}
