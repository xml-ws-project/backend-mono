using MongoDB.Driver;
using MonoLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Context
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name) where TEntity : class;
        Task<int> SaveChanges();
        void AddCommand(Func<Task> func);
    }
}
