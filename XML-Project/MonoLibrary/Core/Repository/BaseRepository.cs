using MonoLibrary.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        //Odraditi kad se ubaci Context
        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
