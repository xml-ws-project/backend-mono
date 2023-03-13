<<<<<<< HEAD
﻿using System;
=======
﻿using MongoDB.Driver;
using System;
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository.Core
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
<<<<<<< HEAD
        void Add (TEntity entity);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(string id);
        Task<bool> Commit();
=======
        TEntity Add (TEntity entity);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        void Remove(string id);
        Task<bool> Commit();
        IMongoCollection<TEntity> GetCollection();
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
    }
}
