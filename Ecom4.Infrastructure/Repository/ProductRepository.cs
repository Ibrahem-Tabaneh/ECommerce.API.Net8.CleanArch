using Ecom4.Core.Entities.Product;
using Ecom4.Core.Helper;
using Ecom4.Core.IRepository;
using Ecom4.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Infrastructure.Repository
{
    public class ProductRepository :GenricRepository<Product> ,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }
        public async Task<Product> GetProductByIdWithDetailsAsync(Guid id)
        {
            var product = await context.Products
                .Include(p => p.Photos)
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

      public async Task<Pagination<Product>> GetAllProductsWithDetailsAsync(QueryProductParams prams)
        { 
            var products =  context.Products
                .Include(p => p.Photos)
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            //filtering  by word
            if (!prams.search.IsNullOrEmpty())
            {
                string[] strings = prams.search.Split(' ').ToArray();
                foreach (var str in strings)
                {
                    products = products.Where(p => p.Name.ToLower()
                    .Contains(str.ToLower()) || p.Description.ToLower().Contains(str.ToLower()));
                }
            }
            //filtering by category
            if (prams.categoryid!=null)
            {
                products = products.Where(p => p.CategoryId == prams.categoryid);
            }
            //get total items after filtering
            int totalItems = await products.CountAsync();

            //sorting
            if (!prams.sort.IsNullOrEmpty())
            {
                switch (prams.sort)
                {
                    case "priceAsync":
                        products = products.OrderBy(p => p.NewPrice);
                        break;
                    case "priceDesc":
                        products = products.OrderByDescending(p => p.NewPrice);
                        break;
                    default:
                        products = products.OrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                products = products.OrderBy(p => p.Name);
            }

            prams.pagenumber = prams.pagenumber <= 0 ? 1 : prams.pagenumber;
            prams.pagesize = prams.pagesize <= 0 ? 9 : prams.pagesize;
            prams.pagesize = prams.pagesize > 50 ? 50 : prams.pagesize;

            products = products.Skip((prams.pagenumber - 1) * prams.pagesize).Take(prams.pagesize);

            var items = await products.ToListAsync();
            var result = new Pagination<Product>
            {
                pageNumber = prams.pagenumber,
                pageSize = prams.pagesize,
                totalItems = totalItems,
                Items = items
            };

            return ( result);
        }

    }
}
