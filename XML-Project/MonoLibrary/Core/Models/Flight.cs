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
        public Flight()
        {
        }

        public Flight(string departurePlace, string landingPlace, string name, double price, DateTime takeoffDateTime, DateTime landingDateTime, int remainingSeats)
        {
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            Name = name;
            Price = price;
            TakeOffDateTime = takeoffDateTime;
            LandingDateTime = landingDateTime;
            RemainingSeats = remainingSeats;
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

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

    }
}
