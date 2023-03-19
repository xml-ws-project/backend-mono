﻿using Microsoft.AspNetCore.Mvc;
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
        
        
        public TicketController(ITicketService ticketService, IFlightService flightService)
        {
            _ticketService = ticketService;
            _flightService = flightService;
        }

        [HttpGet]
        
        public ActionResult<IEnumerable<TicketDTO>> GetAll()
        {
            var tickets = _ticketService.GetAll();
            if (tickets == null)
                return NotFound("There are no tickets found in the system.");
            

            return Ok(GetDTOsFromEntities(tickets));
        }

        [HttpPost]
        public ActionResult<Ticket> Create(CreateTicketDTO dto)
        {
            bool created = _ticketService.Create(dto);
            return Ok(created);
        }

        private List<TicketDTO> GetDTOsFromEntities(IEnumerable<Ticket> tickets)
        {
            var ticketDTOs = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                Flight flight = _flightService.Get(ticket.FlightId);
                TicketDTO dto = TicketMapper.EntityToDTO(ticket, flight);
                ticketDTOs.Add(dto);
            }
            return ticketDTOs;

        }
        

    }
}
