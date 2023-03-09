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

        public virtual async Task Add(TEntity entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.Commit();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            try
            {
                var entity = await _baseRepository.Get(id);
                return entity;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public virtual Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
