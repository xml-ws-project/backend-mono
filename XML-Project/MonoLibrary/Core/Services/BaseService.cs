using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {

        protected readonly IUnitOfWork _unitOfWork;
        protected IBaseRepository<TEntity> _baseRepository;
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }
        public virtual async Task<bool> Add(TEntity entity)
        {
            try
            {
                _baseRepository.Add(entity);
                await _unitOfWork.Commit();
                return true;  
            }
            catch (Exception)
            {
                return false;
            }
        }
        public virtual TEntity Get(string id)
        {
            try
            {
                var entity = _baseRepository.Get(id);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                var entities = _baseRepository.GetAll();
                return entities;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual async Task<bool> Update(TEntity entity) 
        {
            try
            {
                _baseRepository.Update(entity);
                await _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Remove(string id) 
        {
            try
            {
                var entity = Get(id);
                (entity as Entity).Deleted = true;
                Update(entity);
                await _unitOfWork.Commit(); 
                return true;

                //_baseRepository.Remove(id);
                //await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
