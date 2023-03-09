using MongoDB.Bson.Serialization.Attributes;
using MonoLibrary.Core.DbSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Model
{
    [BsonCollection("flights")]
    public class Flight : Entity
    {
        public Flight(string name, double price)
        {
            Name = name;
            Price = price;
        }

        //[BsonElement("takeoff")]
        //[JsonPropertyName("takeoff")]
        //public DateTime TakeoffDate { get; set; }

        //[BsonElement("landing")]
        //[JsonPropertyName("landing")]
        //public DateTime LandingDate { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

    }
}
