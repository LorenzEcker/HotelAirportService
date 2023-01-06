using HotelAirportService.Domain.Base;

namespace HotelAirportService.Domain
{
    public class Ride : HotelAirportServiceBaseEntity
    {
        public Driver Driver { get; set; }
        public Guid DriverId { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public Airport Airport { get; set; }
        public Guid AirportId { get; set; }
        public string Notes { get; set; }
    }
}