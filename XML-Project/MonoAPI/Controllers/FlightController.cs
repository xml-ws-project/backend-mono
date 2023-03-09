using Microsoft.AspNetCore.Mvc;
using MonoAPI.DTOs.Flights;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IFlightService _flightService;

        public FlightController(IUnitOfWork unitOfWork, IFlightService flightService)
        {
            _unitOfWork = unitOfWork;
            _flightService = flightService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> Get(int id)
        {
            var flight = await _flightService.Get(id);
            if (flight == null)
                return NotFound("There was no flight found with provided id.");

            return Ok(flight);
        }

        [HttpPost]
        public async Task Add([FromBody] NewFlightDTO dto) 
        {
            var newFlight = new Flight(dto.Name, dto.Price);
            await _flightService.Add(newFlight);
            return;
        }
    }
}
