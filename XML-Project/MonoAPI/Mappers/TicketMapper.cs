using MonoAPI.DTOs.Tickets;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Service.Core;
using MonoLibrary.Core.Services.Core;

namespace MonoAPI.Mappers
{
    public class TicketMapper
    {
        public static TicketDTO EntityToDTO(Ticket ticket, Flight flight, User user)
        {
            return new TicketDTO(ticket.Id, ticket.Price, ticket.SeatNumber, ticket.AdditionalLuggage, flight.DeparturePlace, flight.LandingPlace, flight.TakeOffDateTime, flight.LandingDateTime, user.FirstName, user.LastName,ticket.PassengerClass);
        }

        public static Ticket NewDTOToEntity(NewTicketDTO dto)
        {
            //srediti mapper za pravljenje kreiranje nove karte
            return new Ticket();
        }
    }
}
