using AutoMapper;
using Ecom4.API.DTOS.ProductDTO;
using Ecom4.API.Helper;
using Ecom4.Core.Entities.Product;
using Ecom4.Core.Helper;
using Ecom4.Core.IRepository;
using Ecom4.Core.IService;
using Ecom4.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom4.API.Controllers
{
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IImageMangmentService imageMangmentService;
        

        public ProductsController(IMapper mapper, IImageMangmentService imageMangmentService, IUnitOfWork unitOfWork) : base(mapper,unitOfWork)
        {
            this.imageMangmentService = imageMangmentService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery]QueryProductParams prams)
        {
           

            var products = await UnitOfWork.ProductRepository.GetAllProductsWithDetailsAsync(prams);

            var productsDTO = mapper.Map<List<ProductDTO>>(products.Items);
            var paginationMetadata = new Pagination<ProductDTO>
            {
                Items = productsDTO,
                pageNumber = products.pageNumber,
                pageSize = products.pageSize,
                totalItems = products.totalItems
            };

            return Ok(new ApiResponse
            {
                statuscode = 200,
                message = "Products retrieved successfully",
                data = paginationMetadata,

            });
        }
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            if (id == null)
            {
                return BadRequest(new ApiResponse
                {
                    statuscode = 400,
                    message = "Invalid product ID",
                    data = null
                });
            }

            var product = await UnitOfWork.ProductRepository.GetProductByIdWithDetailsAsync(id);
            if (product == null)
            {
                return NotFound(new ApiResponse
                {
                    statuscode = 404,
                    message = "Product not found",
                    data = null
                });
            }
            var productDTO = mapper.Map<ProductDTO>(product);
            return Ok(new ApiResponse
            {
                statuscode = 200,
                message = "Product retrieved successfully",
                data = productDTO
            });
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDTO addProductDTO)
        {
            
                if (addProductDTO.Photos.Count != 4 ||addProductDTO.Photos==null)
                {
                    return BadRequest(new ApiResponse
                    {
                        data = null,
                        message = "you have to upload 4 photos exactlly.",
                        statuscode = 400
                    });
                }

            var  product = mapper.Map<Product>(addProductDTO);

                await UnitOfWork.ProductRepository.AddAsync(product);


            var files = addProductDTO.Photos.Select(p => (p.FileName, Content: p.OpenReadStream()));

                var paths = await imageMangmentService.AddImageAsync(files, "products");

                var photos = paths.Select(p => new Photo
                {
                    Path = p,
                    ProductId = product.Id
                }).ToList();
          await UnitOfWork.PhotoRepository.AddRangePhotos(photos);

                return Ok(new ApiResponse
                {
                    statuscode = 200,
                    message = "Product added successfully",
                    data = null
                });
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            
                if (updateProductDTO.Id == null)
                {
                    return BadRequest(new ApiResponse
                    {
                        statuscode = 400,
                        message = "Invalid product ID",
                        data = null
                    });
                }
                var existingProduct = await UnitOfWork.ProductRepository.GetByIdAsync(updateProductDTO.Id);
                if (existingProduct == null)
                {
                    return NotFound(new ApiResponse
                    {
                        statuscode = 404,
                        message = "Product not found",
                        data = null
                    });
                }
                mapper.Map(updateProductDTO, existingProduct);
                await UnitOfWork.ProductRepository.UpdateAsync(existingProduct);


                if (updateProductDTO.Photos != null && updateProductDTO.Photos.Count>0)
                {
                if(updateProductDTO.Photos.Count!=4)
                return BadRequest(new ApiResponse
                {
                    data = null,
                    message = "you have to upload 4 photos exactlly.",
                    statuscode = 400
                });


              await UnitOfWork.PhotoRepository.DeleteRangePhoto(existingProduct.Id);

                var files = updateProductDTO.Photos.Select(p => (p.FileName, Content: p.OpenReadStream()));

                var paths = await imageMangmentService.AddImageAsync(files, "products");
                var photos = paths.Select(p => new Photo
                {
                    Path = p,
                    ProductId = existingProduct.Id
                }).ToList();
                await UnitOfWork.PhotoRepository.AddRangePhotos(photos);
            }  

                return Ok(new ApiResponse
                {
                    statuscode = 200,
                    message = "Product updated successfully",
                    data = null
                });
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
           
                if (id==null)
                {
                    return BadRequest(new ApiResponse
                    {
                        statuscode = 400,
                        message = "Invalid product ID",
                        data = null
                    });
                }
                var existingProduct = await UnitOfWork.ProductRepository.GetByIdAsync(id);

                if (existingProduct == null)
                {
                    return NotFound(new ApiResponse
                    {
                        statuscode = 404,
                        message = "Product not found",
                        data = null
                    });
                }
             
             var Photos = await UnitOfWork.PhotoRepository.GetPhotosByProductId(id);


         await imageMangmentService.DeleteImagesAsync(Photos);
         await UnitOfWork.PhotoRepository.DeleteRangePhoto(id);
         await UnitOfWork.ProductRepository.DeleteAsync(existingProduct);

                return Ok(new ApiResponse
                {
                    statuscode = 200,
                    message = "Product deleted successfully",
                    data = null
                });
            
          
        }
    }
}
