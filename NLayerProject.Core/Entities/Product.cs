using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } // Because it's depend on category.
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; } 
        
        // Add Active-Pasive.
        public virtual Category Category { get; set; } // Reference for Category class.
    }
}
