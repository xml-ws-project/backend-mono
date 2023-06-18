using MongoDB.Bson.Serialization.Attributes;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models
{
    [BsonCollection("api-keys")]
    public class ApiKey : Entity
    {
        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [BsonElement("key")]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [BsonElement("expire_in")]
        [JsonPropertyName("expire_in")]
        public int ExpireIn { get; set; }
        public bool CheckIfActive() 
        {
           if (ExpireIn == 0) return true;
           return DateTime.Now > Created.AddMinutes(120 + ExpireIn) ?  false : true;
        }
    }
}
