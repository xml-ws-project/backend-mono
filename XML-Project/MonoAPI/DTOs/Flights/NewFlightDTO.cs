namespace MonoAPI.DTOs.Flights
{
    public class NewFlightDTO
    {
        public string DeparturePlace { get; set; }
        public string LandingPlace { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public int Capacity { get; set; }
        public Dictionary<string, double> Pricelist { get; set; }
        public string FlightLayoutId { get; set; }
        public double BusinessClassPrice { get; set; }
        public double EconomyClassPrice { get; set; }

        public NewFlightDTO()
        {
        }
        public NewFlightDTO(string departurePlace, string landingPlace, DateTime takeOffDateTime, DateTime landingDateTime, string flightLayoutId, double businessClassPrice, double economyClassPrice)
        {
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
            FlightLayoutId = flightLayoutId;
            BusinessClassPrice = businessClassPrice;
            EconomyClassPrice = economyClassPrice;
        }
    }
}
