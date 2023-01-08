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
        private BookingService bookingService;
        private BookingRepository bookingRepository;

        public BookingController(BookingService bookingService, BookingRepository bookingRepository)
        {
            this.bookingService = bookingService;
            this.bookingRepository = bookingRepository;
        }

        [HttpGet("{bId}")]
        public async Task<ActionResult<Booking>> GetIfBookingExistsAsync(Guid bId)
        {
            Booking booking = await bookingRepository.GetByIdAsync(bId);
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
        public ActionResult<Ride?> BookRide([FromBody] RideBookingDto rideBooking)
        {
            Ride? ride = bookingService.TryBookRide(rideBooking);
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
