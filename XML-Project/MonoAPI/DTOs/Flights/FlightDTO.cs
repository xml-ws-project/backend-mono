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
        public int Capacity { get; set; }
        public Dictionary<string, double> Pricelist { get; set; }

        public FlightDTO()
        {
            Pricelist = new Dictionary<string, double>();
        }

        public FlightDTO(string id, string departurePlace, string landingPlace, Dictionary<string, double> pricelist, DateTime takeOffDateTime, DateTime landingDateTime, int remainingSeats, int capacity)
        {
            Id = id;
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            Pricelist = pricelist;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
            RemainingSeats = remainingSeats;
            Capacity = capacity;
        }
    }
}
