using MonoLibrary.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, dynamic> _repositories;
        public UnitOfWork()
        {
            //_context = context
            FlightRepository = new FlightRepository();
        }
        public IFlightRepository FlightRepository { get; set; }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            string type = typeof(TEntity).Name;

            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
                Type repositoryType = typeof(BaseRepository<>);
                _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), null));
                return (IBaseRepository<TEntity>)_repositories[type];
            }
            else if (_repositories.ContainsKey(type)) 
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            return null;
        }
        public int Save()
        {
            //return _context.SaveChanges();
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //_context.Dispose();
            throw new NotImplementedException();
        }
    }
}
