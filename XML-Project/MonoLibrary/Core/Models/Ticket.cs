<<<<<<< HEAD
﻿using MongoDbGenericRepository.Attributes;
=======
﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
using MonoLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
=======
using System.Text.Json.Serialization;
>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
using System.Threading.Tasks;

namespace MonoLibrary.Core.Models
{
    [CollectionName("tickets")]
    public class Ticket : Entity
    {
<<<<<<< HEAD
        
=======
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

>>>>>>> 2ea1682615bfec94e4e76dff9800b34eabf039b5
    }
}
