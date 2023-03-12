using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using MonoLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models
{
    [CollectionName("tickets")]
    public class Ticket : Entity
    {
        public Ticket()
        {

        }

        [BsonElement("seat_number")]
        [JsonPropertyName("seat_number")]
        public int SeatNumber { get; set; }



    }
}
