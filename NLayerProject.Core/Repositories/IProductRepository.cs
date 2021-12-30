using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
     public interface IProductRepository : IRepository<Product> // Make it Generic.
    {
        Task<Product> GetWithCatergoryByIdAsync(int productId);
    }
}
