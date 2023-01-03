using HotelAirportService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0
{
    [ApiController]
    [Route(RouteConstant.ROUTE_NAME)]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class FlightController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Flight>> GetFlightsForRestOfDay()
        {
            return Ok(new List<Flight> { });
        }
    }
}
