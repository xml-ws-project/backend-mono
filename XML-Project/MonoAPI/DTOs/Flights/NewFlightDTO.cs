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
        public NewFlightDTO()
        {
            Pricelist = new Dictionary<string, double>();
        }
        public NewFlightDTO(string departurePlace, string landingPlace, Dictionary<string, double> pricelist, DateTime takeOffDateTime, DateTime landingDateTime, int capacity)
        {
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            Pricelist= pricelist;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
            Capacity = capacity;
        }
    }
}
