using System;
﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository.Core
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add (TEntity entity);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        void Remove(string id);
        Task<bool> Commit();
        IMongoCollection<TEntity> GetCollection();
    }
}
