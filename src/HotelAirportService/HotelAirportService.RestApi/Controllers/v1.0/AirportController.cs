using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> FetchAirports()
        {

        }
    }
}
