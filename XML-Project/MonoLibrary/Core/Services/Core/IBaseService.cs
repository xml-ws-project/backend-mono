using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service.Core
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        Task<bool> Update(TEntity entity);
        Task<bool> Remove(string id);
        Task<bool> Commit();
    }
}
