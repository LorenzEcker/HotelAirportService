using HotelAirportService.DataAccess.repository;
using HotelAirportService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0;

[ApiController]
[ApiVersion("1.0")]
[Route(RouteConstants.DEFAULT_ROUTE_NAME)]
[Produces("application/json")]
public class AirportController : ControllerBase
{
    private IAirportRepository airportRepository;

    public AirportController(IAirportRepository airportRepository)
    {
        this.airportRepository = airportRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Airport>>> GetAllAirportsAsync()
    {
        List<Airport> airports = new List<Airport>();

        airports = (await airportRepository.GetAllAsync()).ToList();

        return Ok(airports);
    }
}