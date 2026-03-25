using System.ComponentModel.DataAnnotations;

namespace Ecom4.API.DTOS.CategoryDTO
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than zero.")]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
