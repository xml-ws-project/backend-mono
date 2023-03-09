using MonoLibrary.Core.Context;
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
        private readonly IMongoDbContext _context;
        public UnitOfWork(IMongoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Commit()
        {
            var changesMade = await _context.SaveChanges();
            return changesMade > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
