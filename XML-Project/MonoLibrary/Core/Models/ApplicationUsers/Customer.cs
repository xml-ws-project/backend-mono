using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models.ApplicationUsers
{
    [CollectionName("customers")]
    public class Customer : User
    {
        public List<Ticket>? Tickets { get; set; }
       
    }
}
