using MonoLibrary.Core.Models.Enums;

namespace MonoAPI.DTOs.Tickets
{
    public class NewTicketDTO
    {
        public int? Number { get; set; }
        public string UserId { get; set; }
        public string FlightId { get; set; }
        public bool AdditionalLuggage { get; set; }
        public PassengerClass PassangerClass { get; set; }
        public int[] SelectedSeats { get; set; }

        public NewTicketDTO()
        {

        }

        public NewTicketDTO(int number, string userId, string flightId, bool additionalLuggage, PassengerClass passengerClass, int[] selectedSeats)
        {
            Number = number;
            UserId = userId;
            FlightId = flightId;
            AdditionalLuggage = additionalLuggage;
            PassangerClass = passengerClass;
            SelectedSeats = selectedSeats;
        }
    }
}
