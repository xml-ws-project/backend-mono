namespace MonoAPI.DTOs.Tickets
{
    public class NewTicketDTO
    {
        public int Number { get; set; }
        public string UserId { get; set; }
        public string FlightId { get; set; }

        public NewTicketDTO()
        {

        }

        public NewTicketDTO(int number, string userId, string flightId)
        {
            Number = number;
            UserId = userId;
            FlightId = flightId;
        }
    }
}
