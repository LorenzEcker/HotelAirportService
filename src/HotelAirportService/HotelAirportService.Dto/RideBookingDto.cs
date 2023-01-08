using HotelAirportService.Domain.Enum;

namespace HotelAirportService.Dto
{
    public class RideBookingDto
    {
        public Guid AirportId { get; set; }
        public Guid BookingId { get; set; }
        public int PassengerCount { get; set; }
        public DateTime TimeAtAirport { get; set; }
        public TravelType Type { get; set; }
    }
}