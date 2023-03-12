namespace MonoAPI.DTOs.Flights
{
    public class NewFlightDTO
    {
        public string DeparturePlace { get; set; }
        public string LandingPlace { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public int RemainingSeats { get; set; }

        public double Price { get; set; }

        public NewFlightDTO()
        {

        }

        public NewFlightDTO(string departurePlace, string landingPlace, DateTime takeOffDateTime, DateTime landingDateTime, int remainingSeats, double price)
        {
            DeparturePlace = departurePlace;
            LandingPlace = landingPlace;
            TakeOffDateTime = takeOffDateTime;
            LandingDateTime = landingDateTime;
            RemainingSeats = remainingSeats;
            Price = price;
        }
    }
}
