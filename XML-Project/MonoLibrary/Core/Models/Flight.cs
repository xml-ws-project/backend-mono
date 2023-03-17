using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Models.Enums;
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
            Pricelist = new Dictionary<PassengerClass, double>();
        }

        public Flight(string departurePlace, string landingPlace, Dictionary<PassengerClass, double> pricelist, DateTime takeoffDateTime, DateTime landingDateTime, int[] economySeats, int[] businessSeats)
        {
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            Pricelist = pricelist;
            TakeOffDateTime = takeoffDateTime;
            LandingDateTime = landingDateTime;
            EconomySeats = economySeats;
            BusinessSeats = businessSeats;
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

        public int GetRemainingSeats(bool isEconomy)
        {
            if (isEconomy)
                return GetEconomy();

            return GetBuisiness();
        }

        private int GetEconomy()
        {
            int sum = 0;
            foreach (int i in EconomySeats)
            {
                if (EconomySeats[i] == 0)
                    sum++;
            }
            return sum;
        }

        private int GetBuisiness()
        {
            int sum = 0;
            foreach (int i in BusinessSeats)
            {
                if (BusinessSeats[i] == 0)
                    sum++;
            }
            return sum;
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
        
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        [BsonElement("pricelist")]
        [JsonPropertyName("pricelist")]
        public Dictionary<PassengerClass, double> Pricelist { get; set; }

        [BsonElement("economy_seats")]
        [JsonPropertyName("economy_seats")]
        public int[] EconomySeats { get; set; }

        [BsonElement("business_seats")]
        [JsonPropertyName("business_seats")]
        public int[] BusinessSeats { get; set; }
        
    }
}
