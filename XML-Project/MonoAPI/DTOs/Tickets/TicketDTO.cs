namespace MonoAPI.DTOs.Tickets
{
    public class TicketDTO
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public int SeatNumber { get; set; }

        public TicketDTO()
        {

        }

        //srediti dto, dodati info leta
        public TicketDTO(string id, int seatNumber)
        {
            Id = id;
            SeatNumber = seatNumber;
        }
    }
}
