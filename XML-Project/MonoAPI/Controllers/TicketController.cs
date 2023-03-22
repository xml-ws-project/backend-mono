using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonoAPI.DTOs.Tickets;
using MonoAPI.Mappers;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Models.ApplicationUsers;
using MonoLibrary.Core.Service;
using MonoLibrary.Core.Service.Core;
using MonoLibrary.Core.Services.Core;
using CreateTicketDTO = MonoLibrary.Core.DTOs.CreateTicketDTO;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        private IFlightService _flightService;
        private UserManager<User> _userManager;
        
        
        public TicketController(ITicketService ticketService, IFlightService flightService, UserManager<User> userManager)
        {
            _ticketService = ticketService;
            _flightService = flightService;
            _userManager = userManager;
        }

        [HttpGet]
        
        public ActionResult<IEnumerable<TicketDTO>> GetActiveTicketsForUser(string id)
        {
            var tickets = _ticketService.GetActiveTicketsForUser(id);
            if (tickets == null)
                return NotFound("There are no tickets found in the system.");
            

            return Ok(GetDTOsFromEntities(tickets));
        }

        [HttpPost]
        public ActionResult<Ticket> Create(CreateTicketDTO dto)
        {
            bool created = _ticketService.Create(dto);
            if (created)
            {
                return Ok(created);
            }
            else
            {
                return BadRequest("Data is incorrect");
            }
            
        }

        private IEnumerable<TicketDTO> GetDTOsFromEntities(IEnumerable<Ticket> tickets)
        {
            var ticketDTOs = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                Flight flight = _flightService.Get(ticket.FlightId);
                User user = GetUserById(ticket.UserId).Result;
                TicketDTO dto = TicketMapper.EntityToDTO(ticket, flight,user);
                ticketDTOs.Add(dto);
            }
            return ticketDTOs;

        }
        
        private async Task<User> GetUserById(string id)
        { 
            return await _userManager.FindByIdAsync(id);
        }

    }
}
