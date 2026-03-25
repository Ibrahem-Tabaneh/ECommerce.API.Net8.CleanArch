using Ecom4.Core.IRepository;
using Ecom4.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { set; get; }
        public IProductRepository ProductRepository { set; get; }
        public IPhotoRepository PhotoRepository { set; get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            CategoryRepository=new CategoryRepository(dbContext);
            ProductRepository=new ProductRepository(dbContext);
            PhotoRepository=new PhotoRepository(dbContext);
        }

    }
}
