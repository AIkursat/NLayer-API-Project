using NLayerProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category> // Make it Generic.
    {
        Task<Category> GetWithProductByIdAsync(int categoryId);

    }
}
