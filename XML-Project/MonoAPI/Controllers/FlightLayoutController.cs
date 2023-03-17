using Microsoft.AspNetCore.Mvc;
using MonoAPI.DTOs.FlightLayout;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Models;
using MonoLibrary.Core.Services.Core;

namespace MonoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightLayoutController : ControllerBase
    {
        private IFlightLayoutService _flightLayoutService;

        public FlightLayoutController(IFlightLayoutService flightLayoutService)
        {
            _flightLayoutService = flightLayoutService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] NewFlightLayoutDTO dto)
        {
            var result = await _flightLayoutService.Add(new FlightLayout(dto.BusinessLayout, dto.EconomyLayout, dto.NumOfBusiness, dto.NumOfEconomy));

            if (!result)
                return BadRequest("Something went wrong, try again later");

            return Ok("Layout added.");
        }

        [HttpGet("{id}")]
        public ActionResult<FlightLayout> Get(string id)
        {
            var layout = _flightLayoutService.Get(id);
            if (layout == null)
                return NotFound("There is no layout with provided id.");

            return Ok(layout);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlightLayout>> GetAll()
        {
            var layouts = _flightLayoutService.GetAll();
            if (layouts == null)
                return NotFound("There are no layouts found in the system.");

            return Ok(layouts);
        }
    }
}
