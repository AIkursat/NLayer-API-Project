using System.Collections;
using System.Collections.Generic;

namespace NLayerProject.API.DTOs
{
    public class CategoryWithProductDTO :CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
