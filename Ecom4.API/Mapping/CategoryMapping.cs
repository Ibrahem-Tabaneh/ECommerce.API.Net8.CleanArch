using AutoMapper;
using Ecom4.API.DTOS.CategoryDTO;
using Ecom4.Core.Entities.Product;

namespace Ecom4.API.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<AddCategoryDTO,Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
