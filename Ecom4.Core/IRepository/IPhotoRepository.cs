using Ecom4.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Core.IRepository
{
    public interface IPhotoRepository:IGenricRepository<Photo>
    {

        //future methods
        Task AddRangePhotos(List<Photo> photos);
        Task DeleteRangePhoto(Guid productId);
        Task<List<string>> GetPhotosByProductId(Guid productId);

    }
}
