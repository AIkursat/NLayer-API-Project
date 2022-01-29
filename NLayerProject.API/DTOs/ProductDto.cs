using System.ComponentModel.DataAnnotations;

namespace NLayerProject.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} can't be empty.")] // {0} placeholder, represent to Name.
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} must be higher than 1.")]
        public int Stock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} must be higher than 1.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
