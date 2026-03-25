using Ecom4.Core.Entities.Product;
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
    public class PhotoRepository:GenricRepository<Photo> ,IPhotoRepository
    {
        public PhotoRepository(AppDbContext context) :base(context) 
        {
            
        }
        public async Task AddRangePhotos(List<Photo> photos)
        {
            await context.Photos.AddRangeAsync(photos);
            await context.SaveChangesAsync();
        }
        public async Task DeleteRangePhoto(Guid productId)
        {
            var photos = context.Photos.Where(p => p.ProductId == productId).ToList();
        
            context.Photos.RemoveRange(photos);
            await context.SaveChangesAsync();
        }
       public async Task<List<string>> GetPhotosByProductId(Guid productId)
        {
            var photos = await context.Photos.Where(p => p.ProductId == productId).ToListAsync();

            var photoPaths = photos.Select(p => p.Path).ToList();

            return photoPaths;
        }


    }
}
