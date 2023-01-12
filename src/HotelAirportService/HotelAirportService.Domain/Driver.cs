using System.Text.Json.Serialization;
using HotelAirportService.Domain.Base;

namespace HotelAirportService.Domain
{
    public class Driver : HotelAirportServiceBaseEntity
    {
        public int Seats { get; set; }
        public string DriverName { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
