﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonoAPI.AuthToken;
using MonoAPI.DTOs.Flights;
using MonoAPI.Mappers;
using MonoLibrary.Core.DTOs;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;
        private ITokenService _tokenService;
        public FlightController(IFlightService flightService, ITokenService tokenService)
        {
            _flightService = flightService;
            _tokenService = tokenService; 
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewFlightDTO dto)
        {
            var newFlight = FlightMapper.NewDTOToEntity(dto);
            var result = await _flightService.Add(newFlight);

            if (!result)
                return BadRequest("Something went wrong, try again later");

            return Ok("Flight added.");
        }

        [Authorize]
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

                return Ok(flight);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(string id) 
        {
            var result = await _flightService.Remove(id);
            if (!result)
                return BadRequest("Something went wrong, try again later.");

            return Ok("Flight removed.");
        }

        [HttpPost("search")]
        public ActionResult SearchFlights(SearchFlightDTO dto)
        {
            if (dto == null)
                return BadRequest();

            return Ok(FlightMapper.EntityListToEntityDTOList(_flightService.SearchFlights(dto).ToList()));
        }
    }
}
