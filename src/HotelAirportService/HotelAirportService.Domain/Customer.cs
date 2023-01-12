using System.Text.Json.Serialization;
using HotelAirportService.Domain.Base;

namespace HotelAirportService.Domain
{
    public class Customer : HotelAirportServiceBaseEntity
    {
        public string CustomerName { get; set; }
        public string AmountOfLuggage { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
