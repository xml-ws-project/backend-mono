using MonoAPI.DTOs.Tickets;
using MonoLibrary.Core.Models;

namespace MonoAPI.Mappers
{
    public class TicketMapper
    {
        public static TicketDTO EntityToDTO(Ticket ticket)
        {
            //srediti mapper, dodati info leta
            return new TicketDTO(ticket.Id, ticket.SeatNumber);
        }

    }
}
