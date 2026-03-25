using System.ComponentModel.DataAnnotations;

namespace Ecom4.API.DTOS.CategoryDTO
{
    public class AddCategoryDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
