using HotelAirportService.DataAccess.repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0;

[ApiController]
[ApiVersion("1.0")]
[Route(RouteConstants.DEFAULT_ROUTE_NAME)]
[Produces("application/json")]
public class RideController : ControllerBase
{
    private IRideRepository rideRepository;

    public RideController(IRideRepository rideRepository)
    {
        this.rideRepository = rideRepository;
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteRide(Guid id)
    {
        return Ok(rideRepository.SoftDeleteAsync(id));
    }

}