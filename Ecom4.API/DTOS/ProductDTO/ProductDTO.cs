using Ecom4.Core.Entities.Product;

namespace Ecom4.API.DTOS.ProductDTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; } = new HashSet<PhotoDTO>();
    }

    public class PhotoDTO
    {
        public string? Path { get; set; }
    }
}
