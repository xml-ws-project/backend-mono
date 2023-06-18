using MonoLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Repository.Core
{
    public interface IApiKeyRepository : IBaseRepository<ApiKey>
    {
        ApiKey GetByUserId(string userId);
    }
}
