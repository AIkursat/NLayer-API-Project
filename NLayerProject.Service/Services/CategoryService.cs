using NLayerProject.Core.Entities;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
           return await _unitOfWork.Categories.GetWithProductByIdAsync(categoryId); // _unitOfWork service'den geliyor.
        }
    }
}
