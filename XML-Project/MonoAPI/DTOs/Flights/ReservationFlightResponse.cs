namespace MonoAPI.DTOs.Flights
{
    public class ReservationFlightResponse
    {
        public List<FlightDTO> Start { get; set; }
        public List<FlightDTO> End { get; set; }
    }
}
