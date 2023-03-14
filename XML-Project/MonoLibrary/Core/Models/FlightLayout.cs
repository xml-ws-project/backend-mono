using MongoDB.Bson.Serialization.Attributes;
using MonoLibrary.Core.DbSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models
{
    [BsonCollection("layouts")]
    public class FlightLayout
    {
        [BsonElement("layout")]
        [JsonPropertyName("layout")]
        public string[]? Layout { get; set; }

        [BsonElement("number_of_business")]
        [JsonPropertyName("number_of_business")]
        public int NumOfBusiness { get; set; }

        [BsonElement("number_of_economy")]
        [JsonPropertyName("number_of_economy")]
        public int NumOfEconomy { get; set; }

        public FlightLayout()
        {

        }

        public FlightLayout(string[] layout, int numOfBusiness, int numOfEconomy)
        {
            Layout = layout;
            NumOfBusiness = numOfBusiness;
            NumOfEconomy = numOfEconomy;
        }
    }
}
