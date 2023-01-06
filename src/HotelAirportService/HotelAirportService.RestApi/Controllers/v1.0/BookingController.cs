using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> GetBooking([FromQuery] string bId)
        {
            return Ok(1);
        }
    }
}
