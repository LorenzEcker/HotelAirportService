using HotelAirportService.BusinessLogic;
using HotelAirportService.DataAccess.repository;
using HotelAirportService.Domain;
using HotelAirportService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HotelAirportService.RestApi.Controllers.v1._0
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(RouteConstants.DEFAULT_ROUTE_NAME)]
    [Produces("application/json")]
    public class BookingController : ControllerBase
    {
        private IBookingService bookingService;
        private IBookingRepository bookingRepository;

        public BookingController(IBookingService bookingService, IBookingRepository bookingRepository)
        {
            this.bookingService = bookingService;
            this.bookingRepository = bookingRepository;
        }

        [HttpGet("{bId}")]
        public async Task<ActionResult<Booking>> GetIfBookingExistsAsync(string bId)
        {
            Booking booking = bookingRepository.GetBookingByBookingId(bId);
            if (booking == null)
            {
                return BadRequest("Non existant booking code");
            }
            else
            {
                return Ok(booking);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Ride?>> BookRide([FromBody] RideBookingDto rideBooking)
        {
            Ride? ride = await bookingService.TryBookRide(rideBooking);
            if (ride == null)
            {
                return BadRequest("Time not available");
            }
            else
            {
                return Ok(ride);
            }
        }
    }
}
