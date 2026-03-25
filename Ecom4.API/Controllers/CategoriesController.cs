
using AutoMapper;
using Ecom4.API.DTOS.CategoryDTO;
using Ecom4.API.Helper;
using Ecom4.Core.Entities.Product;
using Ecom4.Core.Helper;
using Ecom4.Core.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Ecom4.API.Controllers
{
    [ApiController]
    public class CategoriesController : BaseController
    {

        public CategoriesController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }
        

        [HttpGet("get-all")]
        public async Task<IActionResult> get([FromQuery] QueryCategoryParams prams)
        {
           
                var categories = await UnitOfWork.CategoryRepository.GetAllPaginationAsync(prams);

               var paginationMetadata = new Pagination<CategoryDTO>
                {
                    Items = mapper.Map<List<CategoryDTO>>(categories.Items),
                    pageNumber = categories.pageNumber,
                    pageSize = categories.pageSize,
                    totalItems = categories.totalItems
                };

            return Ok(new ApiResponse
            {
                statuscode = 200,
                message = "Categories retrieved successfully",
                data = paginationMetadata,

            });
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
           
                var category = await UnitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new ApiResponse
                    {
                        statuscode = 404,
                        message = "Category not found.",
                        data = null
                    });
                }
                var categoryDTO = mapper.Map<CategoryDTO>(category);
                return Ok(new ApiResponse()
                {
                    statuscode = 200,
                    message = "Category retrieved successfully.",
                    data = categoryDTO
                });
           
           
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(AddCategoryDTO addCategoryDTO)
        {
           
                var category = mapper.Map<Category>(addCategoryDTO);
                await UnitOfWork.CategoryRepository.AddAsync(category);
                return Ok(new ApiResponse
                {
                    statuscode = 200,
                    message = "Category added successfully.",
                    data = null
                });
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(UpdateCategoryDTO updateCategoryDTO)
        {
           
                var existingCategory = await UnitOfWork.CategoryRepository.GetByIdAsync(updateCategoryDTO.Id);

                if (existingCategory == null)
                {
                    return NotFound(new ApiResponse
                    {
                        statuscode = 404,
                        message = "Category not found.",
                        data = null
                    });
                }

                mapper.Map(updateCategoryDTO, existingCategory);
                await UnitOfWork.CategoryRepository.UpdateAsync(existingCategory);
                return Ok(new ApiResponse
                {
                    statuscode = 200,
                    message = "Category updated successfully.",
                    data = null
                });
            

        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(Guid id)
        {
           
                if (id==null)
                {
                    return BadRequest(new ApiResponse
                    {
                        statuscode = 400,
                        message = "Invalid category ID.",
                        data = null
                    });
                }

                var existingCategory = await UnitOfWork.CategoryRepository.GetByIdAsync(id);
                if (existingCategory == null)
                {
                    return NotFound(new ApiResponse
                    {
                        statuscode = 404,
                        message = "Category not found.",
                        data = null
                    });
                }
                await UnitOfWork.CategoryRepository.DeleteAsync(existingCategory);
                return Ok(new ApiResponse
                {
                    statuscode = 200,
                    message = "Category deleted successfully.",
                    data = null
                });
            
        }
    }
}
