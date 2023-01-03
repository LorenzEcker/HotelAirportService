using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public IActionResult GetArrivals()
        {
            return Ok();
        }

        public IActionResult GetDepartures()
        {
            return Ok();
        }
    }
}
