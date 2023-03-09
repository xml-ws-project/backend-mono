using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository.Core
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add (TEntity entity);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(int id);

        //void Delete(TEntity entity);
    }
}
