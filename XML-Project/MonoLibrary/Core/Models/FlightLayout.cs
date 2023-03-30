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
    [BsonCollection("layouts")]
    public class FlightLayout : Entity
    {
        [BsonElement("economy_layout")]
        [JsonPropertyName("economy_layout")]
        public string[]? EconomyLayout { get; set; }

        [BsonElement("business_layout")]
        [JsonPropertyName("business_layout")]
        public string[]? BusinessLayout { get; set; }

        [BsonElement("number_of_business")]
        [JsonPropertyName("number_of_business")]
        public int NumOfBusiness { get; set; }

        [BsonElement("number_of_economy")]
        [JsonPropertyName("number_of_economy")]
        public int NumOfEconomy { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public FlightLayout()
        {

        }

        public FlightLayout(string[] businessLayout, string[] economyLayout, int numOfBusiness, int numOfEconomy, string name)
        {
            BusinessLayout = businessLayout;
            EconomyLayout = economyLayout;
            NumOfBusiness = numOfBusiness;
            NumOfEconomy = numOfEconomy;
            Name = name;
        }
    }
}
