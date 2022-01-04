using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class // It's mean that have to be class.
    {
        // Create the DbCOntext object
        public readonly DbContext _context;
        public DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context; // In order to Reach the Database
            _dbSet = context.Set<TEntity>(); // In order to reach Db Tables. If product comes to TEntity, we work on product for example.
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); 
        }

        public async Task<TEntity> GetbyIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity) // made void because there is no returning type.
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) // It' get entity and return bool.
        {
           return await _dbSet.SingleOrDefaultAsync(predicate); // Get me first record, if it's not exist get me default.
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
