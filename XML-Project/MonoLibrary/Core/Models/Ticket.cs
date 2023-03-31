using MongoDbGenericRepository.Attributes;
﻿using MongoDB.Bson.Serialization.Attributes;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models.Enums;
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

        public Ticket(int seatNumber, string userId, string flightId, double price, bool additionalLuggage, PassengerClass passengerClass)
        {
            SeatNumber = seatNumber;
            UserId = userId;
            FlightId = flightId;
            Price = price;
            AdditionalLuggage = additionalLuggage;
            PassengerClass = passengerClass;
        }

        [BsonElement("seat_number")]
        [JsonPropertyName("seat_number")]
        public int SeatNumber { get; set; }

        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [BsonElement("flight_id")]
        [JsonPropertyName("flight_id")]
        public string FlightId { get; set; }

        [BsonElement("price")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [BsonElement("additional_luggage")]
        [JsonPropertyName("additional_luggage")]
        public bool AdditionalLuggage { get; set; }

        [BsonElement("passenger_class")]
        [JsonPropertyName("passenger_class")]
        public PassengerClass PassengerClass { get; set; }
    }
}
