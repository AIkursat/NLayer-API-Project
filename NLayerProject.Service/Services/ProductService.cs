using NLayerProject.Core.Entities;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//using System.Data.Entity;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<List<Product>> GetAllCategoriesAsync() // Generic IResult.
        {
            return await _unitOfWork.Products.GetAllCategoriesAsync(); // Promise
        }

        public async Task<Product> GetWithCatergoryByIdAsync(int productId) // Generic IResult.
        {
            return await _unitOfWork.Products.GetWithCatergoryByIdAsync(productId); // Promise
        }
    }
}
