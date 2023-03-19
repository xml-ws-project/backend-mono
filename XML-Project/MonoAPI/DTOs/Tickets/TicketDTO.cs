using MonoLibrary.Core.Models.Enums;

namespace MonoAPI.DTOs.Tickets
{
    public class TicketDTO
    {
        public string? Id { get; set; }
        public double Price { get; set; }
        public int SeatNumber { get; set; }
        public bool AdditionalLuggage { get; set; }
        public string? DeparturePlace { get; set; }
        public string? LandingPlace { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        public TicketDTO()
        {

        }

        public TicketDTO(string id, double price, int seatNumber, bool additionalLuggage, string departurePlace, string landingPlace, DateTime takeOffDateTime, DateTime landingDateTime, string firstname, string lastname)
        {
            Id = id;
            Price = price;
            SeatNumber = seatNumber;
            AdditionalLuggage = additionalLuggage;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
            Firstname = firstname;
            Lastname = lastname;
        }

        public TicketDTO(string id, double price, int seatNumber, bool additionalLuggage, string departurePlace, string landingPlace, DateTime takeOffDateTime, DateTime landingDateTime)
        {
            Id = id;
            Price = price;
            SeatNumber = seatNumber;
            AdditionalLuggage = additionalLuggage;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
        }
    }
}
