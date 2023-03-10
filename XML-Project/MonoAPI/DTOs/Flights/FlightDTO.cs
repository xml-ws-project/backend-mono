namespace MonoAPI.DTOs.Flights
{
    public class FlightDTO
    {
        public string Id { get; set; }
        public string DeparturePlace { get; set; }
        public string LandingPlace { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public int RemainingSeats { get; set; }

        public FlightDTO()
        {

        }

        public FlightDTO(string id, string departurePlace, string landingPlace, DateTime takeOffDateTime, DateTime landingDateTime, int remainingSeats)
        {
            Id = id;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
            RemainingSeats = remainingSeats;
        }
    }
}
