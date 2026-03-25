using AutoMapper;
using Ecom4.API.DTOS.ProductDTO;
using Ecom4.Core.Entities.Product;

namespace Ecom4.API.Mapping
{
    public class ProductMapping :Profile
    {
        public ProductMapping()
        {
            //ProductDTO
            CreateMap<Product, ProductDTO>().ForMember(x => x.CategoryName
                        , op => op.MapFrom(src => src.Category.Name));

            //AddProductDTO
            CreateMap<AddProductDTO, Product>()
     .ForMember(dest => dest.Photos, opt => opt.Ignore());

            //UpdateProductDTO
            CreateMap<UpdateProductDTO, Product>()
    .ForMember(dest => dest.Photos, opt => opt.Ignore());

        }
    }
}
