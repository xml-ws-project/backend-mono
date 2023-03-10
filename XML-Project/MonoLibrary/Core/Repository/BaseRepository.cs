using MongoDB.Bson;
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
        public virtual void Add(TEntity entity)
        {
            (entity as Entity).Created = DateTime.Now;
            (entity as Entity).Updated = DateTime.Now;
            _context.AddCommand(() => _dbSet.InsertOneAsync(entity));
        }
        public virtual TEntity Get(string id)
        {
            //Treba i ovde uracunati ove sto imaju Deleted = true
            var data = _dbSet.Find(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)));
            return data.SingleOrDefault();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            var data = _dbSet.Find(Builders<TEntity>.Filter.Eq("deleted", false));
            return data.ToList();
        }
        public virtual void Update(TEntity entity) 
        {
            (entity as Entity).Updated = DateTime.Now;
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse((entity as Entity)?.Id)), entity));
        }
        public void Remove(string id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id))));
        }
        public async Task<bool> Commit()
        {
            var changesMade = await _context.SaveChanges();
            return changesMade > 0;
        }
        public void Dispose() 
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
