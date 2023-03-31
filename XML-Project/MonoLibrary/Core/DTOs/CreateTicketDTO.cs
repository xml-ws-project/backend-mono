using MonoLibrary.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.DTOs
{
    public class CreateTicketDTO
    {
        public int[] SeatNumbers { get; set; }
        public string UserId { get; set; }
        public string FlightId { get; set; }
        public bool AdditionalLuggage { get; set; }
        public PassengerClass PassengerClass { get; set; }
        public int NumberOfTickets { get; set; }

        public CreateTicketDTO() { }

        public CreateTicketDTO(int[] seatNumbers, string userId, string flightId, bool additionalLuggage, PassengerClass passengerClass, int numberOfTickets)
        {
            SeatNumbers = seatNumbers;
            UserId = userId;
            FlightId = flightId;
            AdditionalLuggage = additionalLuggage;
            PassengerClass = passengerClass;
            NumberOfTickets = numberOfTickets;
        }
    }
}

