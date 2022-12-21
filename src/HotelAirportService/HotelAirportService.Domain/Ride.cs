using HotelAirportService.Domain.Base;

namespace HotelAirportService.Domain
{
    public class Ride : HotelAirportServiceBaseEntity
    {
        public Flight Flight { get; set; }
        public Driver Driver { get; set; }
        public Customer Customer { get; set; }
        public string Notes { get; set; }

    }
}