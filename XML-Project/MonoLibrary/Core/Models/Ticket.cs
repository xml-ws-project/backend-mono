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

        public Ticket(int seatNumber, string userId, int flightId, double price)
        {
            SeatNumber = seatNumber;
            UserId = userId;
            FlightId = flightId;
            Price = price;
        }

        [BsonElement("seat_number")]
        [JsonPropertyName("seat_number")]
        public int SeatNumber { get; set; }

        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [BsonElement("flight_id")]
        [JsonPropertyName("flight_id")]
        public int FlightId { get; set; }

        [BsonElement("price")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

    }
}
