using MongoDB.Driver;
using MonoLibrary.Core.Context;
using MonoLibrary.Core.Model;
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
        protected readonly IMongoDbContext _context;
        protected IMongoCollection<TEntity> _dbSet { get; private set; }

        public BaseRepository(IMongoDbContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task Add(TEntity entity)
        {
            _context.AddCommand(() => _dbSet.InsertOneAsync(entity));
        }
        public virtual async Task<TEntity> Get(int id)
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return data.ToList();
        }

        public virtual async Task Update(TEntity entity) 
        {
            //moze i preko interfaca za IEntity
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", (entity as Entity)?.Id), entity));
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose() 
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
