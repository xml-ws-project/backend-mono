﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MonoAPI.AuthToken;
using MonoAPI.DTOs.Flights;
using MonoAPI.Mappers;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Service.Core;
using MonoLibrary.Core.Services.Core;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;
        private ITokenService _tokenService;
        private IFlightLayoutService _flightLayoutService;


        public FlightController(IFlightLayoutService flightLayoutService,
                                IFlightService flightService,
                                ITokenService tokenService
                                )
        {
            _flightLayoutService = flightLayoutService;
            _flightService = flightService;
            _tokenService = tokenService;

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(NewFlightDTO dto)
        {
            var flightLayout = _flightLayoutService.Get(dto.FlightLayoutId);
            var newFlight = FlightMapper.NewDTOToEntity(dto, flightLayout);
            var result = await _flightService.Add(newFlight);

            if (!result)
                return BadRequest("Something went wrong, try again later");

            return Ok("Flight added.");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN, CUSTOMER")]
        [HttpGet("{id}")]
        public ActionResult<Flight> Get(string id)
        {
            string token = Request.Headers["Authorization"];
            if (token == null || !_tokenService.ValidateToken(token))
                return BadRequest("Unable to authorize.");
            else 
            {
                var flight = _flightService.Get(id);
                if (flight == null)
                    return NotFound("There is no flight with provided id.");

                return Ok(FlightMapper.EntityToAdminFlightDTO(flight));
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flight>> GetAll() 
        {
            var flights = _flightService.GetAll();
            if (flights == null)
                return NotFound("There are no flights found in the system.");

            return Ok(flights);
        }

        [HttpPost("search")]
        public ActionResult SearchFlights(SearchFlightDTO dto)
        {
            if (dto == null)
                return BadRequest();
            var flights = _flightService.SearchFlights(dto).ToList();
            return Ok(FlightMapper.EntityListToEntityDTOList(flights));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var flight = _flightService.Get(id);
            if (flight == null)
                return NotFound("Flight with provided id doesen't exist.");

            var result = await _flightService.Remove(id);
            return result ? Ok(("Flight removed.").ToJson()) : BadRequest(("Something went wrong.").ToJson());
        }

        [HttpPost("/update")]
        public  ActionResult<Flight> Update(String id, int[] seats)
        { 
            var result = _flightService.UpdateFlight(id,seats);
            return Ok(result);
        }

        [HttpPut("for/reservation")]
        public ActionResult<IEnumerable<FlightDTO>> ReservationFlights(ReservationFlightRequest request)
        {
            var result = _flightService.FindReservationFlights(request);
            return result == null ? NotFound(null) : Ok(FlightMapper.EntityListToEntityDTOList(result));
        }
    }
}
