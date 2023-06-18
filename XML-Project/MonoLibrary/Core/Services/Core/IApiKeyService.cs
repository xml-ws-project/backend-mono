using MonoLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Services.Core
{
    public interface IApiKeyService
    {
        List<ApiKey> GetByUserId(string id);
        List<ApiKey> GetAll();
        ApiKey Create(string userId, int expireIn);

        bool Validate(string value);
    }
}
