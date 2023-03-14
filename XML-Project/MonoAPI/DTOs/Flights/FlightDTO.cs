using MonoLibrary.Core.Models.Enums;

namespace MonoAPI.DTOs.Flights
{
    public class FlightDTO
    {
        public string? Id { get; set; }
        public string? DeparturePlace { get; set; }
        public string? LandingPlace { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public Dictionary<PassengerClass, double> Pricelist { get; set; }

        public FlightDTO()
        {
            Pricelist = new Dictionary<PassengerClass, double>();
        }

        public FlightDTO(string id, string departurePlace, string landingPlace, Dictionary<PassengerClass, double> pricelist, DateTime takeOffDateTime, DateTime landingDateTime)
        {
            Id = id;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            Pricelist = pricelist;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
        }
    }
}
