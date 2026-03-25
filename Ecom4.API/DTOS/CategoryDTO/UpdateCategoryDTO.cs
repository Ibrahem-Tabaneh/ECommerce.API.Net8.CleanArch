using System.ComponentModel.DataAnnotations;

namespace Ecom4.API.DTOS.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than zero.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
