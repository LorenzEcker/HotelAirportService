using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(RouteConstants.DEFAULT_ROUTE_NAME)]
    [Produces("application/json")]
    public class BookingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> GetBooking([FromQuery] string bId)
        {
            return Ok(1);
        }
    }
}
