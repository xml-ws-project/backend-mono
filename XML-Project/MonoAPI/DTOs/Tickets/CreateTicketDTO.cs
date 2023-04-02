using MonoLibrary.Core.Models.Enums;

namespace MonoAPI.DTOs.Tickets
{
    public class CreateTicketDTO
    {
        public int[] SeatNumber { get; set; }
        public string UserId { get; set; }
        public string FlightId { get; set; }
        public bool AdditionalLuggage { get; set; }
        public PassengerClass PassengerClass { get; set; }
        public int NumberOfTickets { get; set; }

        public CreateTicketDTO() { }

        public CreateTicketDTO(int[] seatNumber, string userId, string flightId, bool additionalLuggage, PassengerClass passengerClass, int numberOfTickets)
        {
            SeatNumber = seatNumber;
            UserId = userId;
            FlightId = flightId;
            AdditionalLuggage = additionalLuggage;
            PassengerClass = passengerClass;
            NumberOfTickets = numberOfTickets;
        }
    }
}
