using MonoLibrary.Core.Models;
using MonoLibrary.Core.Context;
using MonoLibrary.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository
{
    public class ApiKeyRepository : BaseRepository<ApiKey>, IApiKeyRepository
    {
        private readonly IMongoDbContext _context;
        public ApiKeyRepository(IMongoDbContext context) : base(context)
        {
            _context = context;
        }
    
        public ApiKey GetByUserId(string userId) 
        {
            return GetAll().Where(key => key.UserId.Equals(userId)).FirstOrDefault();
        }
    }
}
