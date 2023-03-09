using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Model
{
    public class Entity
    {
        [BsonId]
        public int Id { get; set; }
        
        [BsonElement("created")]
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [BsonElement("updated")]
        [JsonPropertyName("updated")]
        public DateTime Updated { get; set; }

        [BsonElement("deleted")]
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
        
        public Entity(){}
    }
}
