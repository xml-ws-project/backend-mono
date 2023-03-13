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
<<<<<<< HEAD
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
=======
        public Flight()
        {
            Pricelist = new Dictionary<string, double>();
        }

        public Flight(string departurePlace, string landingPlace, Dictionary<string, double> pricelist, DateTime takeoffDateTime, DateTime landingDateTime, int remainingSeats, int capacity)
        {
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            Pricelist = pricelist;
            TakeOffDateTime = takeoffDateTime;
            LandingDateTime = landingDateTime;
            RemainingSeats = remainingSeats;
            Capacity = capacity;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Flight;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        [BsonElement("departure_place")]
        [JsonPropertyName("departure_place")]
        public string DeparturePlace { get; set; }

        [BsonElement("landing_place")]
        [JsonPropertyName("landing_place")]
        public string LandingPlace { get; set; }

        [BsonElement("takeoff_datetime")]
        [JsonPropertyName("takeoff_datetime")]
        public DateTime TakeOffDateTime { get; set; }

        [BsonElement("landing_datetime")]
        [JsonPropertyName("landing_datetime")]
        public DateTime LandingDateTime { get; set; }

        [BsonElement("remaining_seats")]
        [JsonPropertyName("remaining_seats")]
        public int RemainingSeats { get; set; }

        [BsonElement("capacity")]
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [BsonElement("pricelist")]
        [JsonPropertyName("pricelist")]
        public Dictionary<string, double> Pricelist { get; set; }
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5

    }
}
