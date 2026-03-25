using AutoMapper;
using Ecom4.API.DTOS.ProductDTO;
using Ecom4.Core.Entities.Product;

namespace Ecom4.API.Mapping
{
    public class PhotoMapping:Profile
    {
        public PhotoMapping()
        {
            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
