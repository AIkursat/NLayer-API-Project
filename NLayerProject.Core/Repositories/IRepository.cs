﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetbyIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task <IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); // Because where is not generic. Make the QUareble.

        // category.SingleOrDefault(x => x.name = "Sample Product."
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        // It's for one more register.
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);    
        TEntity Update(TEntity entity);

    }
}
