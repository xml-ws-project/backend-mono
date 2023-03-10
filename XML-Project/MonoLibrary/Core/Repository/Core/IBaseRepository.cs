using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository.Core
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add (TEntity entity);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(string id);
        Task<bool> Commit();
    }
}
