using Microsoft.AspNetCore.Cors;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class // It'll be generic, because IService is generic too
    {
        // DI Object

        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                await _repository.AddAsync(entity);

                await _unitOfWork.CommitAsync();
                return entity;

            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);

            await _unitOfWork.CommitAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetbyIdAsync(int id)
        {
            
            return await _repository.GetbyIdAsync(id);

        }
      
        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);

            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _repository.Update(entity);

            _unitOfWork.Commit();
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) // task means it's async
        {
            return await _repository.Where(predicate);
        }
    }
}
