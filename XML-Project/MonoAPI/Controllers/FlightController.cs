using Microsoft.AspNetCore.Mvc;
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
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewFlightDTO dto)
        {
            //ovo se treba izmeniti(mozda neki maper)
            var newFlight = FlightMapper.NewDTOToEntity(dto);
            var result = await _flightService.Add(newFlight);

            if (!result)
                return BadRequest("Something went wrong, try again later");

            return Ok("Flight added.");
        }

        [HttpGet("{id}")]
        public ActionResult<Flight> Get(string id)
        {
            var flight = _flightService.Get(id);
            if (flight == null)
                return NotFound("There is no flight with provided id.");

            return Ok(flight);
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
