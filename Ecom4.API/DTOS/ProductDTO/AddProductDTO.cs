using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace Ecom4.API.DTOS.ProductDTO
{
    public class AddProductDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 10 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal OldPrice { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal? NewPrice { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "you should upload 4 photos excactly.")]
        public List<IFormFile> Photos { get; set; }
    }
}
