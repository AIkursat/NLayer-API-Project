using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCatergoryByIdAsync(int productId);
        Task<List<Product>> GetAllCategoriesAsync();

        // bool ControlInnerBarcode(Product product);
    }
}
