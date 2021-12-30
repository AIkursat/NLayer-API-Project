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

        // bool ControlInnerBarcode(Product product);
    }
}
