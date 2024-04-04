using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiRoute_Flight_Combination.Services.Interfaces;

namespace MultiRoute_Flight_Combination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightService.GetAllFlights();
            if (flights == null)
            {
                return BadRequest("Flights Are Not Available");
            }
            return Ok(flights);
 
        }
    }
}
