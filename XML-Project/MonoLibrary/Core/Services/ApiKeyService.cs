using MonoLibrary.Core.Models;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service;
using MonoLibrary.Core.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services
{
    public class ApiKeyService : BaseService<ApiKey>, IApiKeyService
    {
        private readonly IApiKeyRepository _apiKeyRepository;

        public ApiKeyService(IApiKeyRepository apiKeyRepository) : base(apiKeyRepository)
        {
            _apiKeyRepository = apiKeyRepository;
        }

        public ApiKey Create(string userId, int expireIn)
        {
            var newKey = ExecuteCreate(userId, expireIn);
            _apiKeyRepository.Add(newKey);
            _apiKeyRepository.Commit();
            
            return newKey;
        }

        private ApiKey ExecuteCreate(string userId, int expireIn) 
        {
            var apiKey = new ApiKey();
            apiKey.UserId = userId;
            apiKey.ExpireIn = expireIn;
            apiKey.Key = Guid.NewGuid().ToString();

            return apiKey;
        }
        public ApiKey GetById(string id)
        {
            return _apiKeyRepository.Get(id);
        }

        public List<ApiKey> GetAll()
        {
            return _apiKeyRepository.GetAll().ToList();
        }
    }
}
