namespace NLayerProject.API.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; } // Must be same like we wrote Core layer.
    }
}
