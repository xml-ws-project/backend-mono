using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models.ApplicationUsers
{
    [CollectionName("roles")]
    public class Role : MongoIdentityRole<string>
    {
        
    }
}
