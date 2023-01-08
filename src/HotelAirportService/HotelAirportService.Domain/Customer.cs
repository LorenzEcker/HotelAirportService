using System.Text.Json.Serialization;
using HotelAirportService.Domain.Base;

namespace HotelAirportService.Domain
{
    public class Customer : HotelAirportServiceBaseEntity
    {
        public string CustomerName { get; set; }
        public string AmountOfLuggage { get; set; }
        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; }
        [JsonIgnore]
        public ICollection<Ride> Rides { get; set; }
    }
}
