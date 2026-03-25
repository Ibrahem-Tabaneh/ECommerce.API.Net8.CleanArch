using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IPhotoRepository PhotoRepository { get; set; }

    }
}
