using MonoLibrary.Core.Model;
﻿using MongoDB.Driver;
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

        protected IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual async Task<bool> Add(TEntity entity)
        {
            try
            {
                _baseRepository.Add(entity);
                await _baseRepository.Commit();
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
                await _baseRepository.Commit();
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
                await _baseRepository.Commit();
                return true;

                //_baseRepository.Remove(id);
                //await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Commit()
        {
            return await _baseRepository.Commit();
        }
    }
}
