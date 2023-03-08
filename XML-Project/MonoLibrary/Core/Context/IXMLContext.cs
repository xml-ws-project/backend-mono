using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Context
{
    public interface IXMLContext : IDisposable
    {
        IMongoCollection<T> GetCollection<T>(string name);
        Task<int> SaveChanges();
        void AddCommand(Func<Task> func);
    }
}
