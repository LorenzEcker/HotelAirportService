using HotelAirportService.Domain.Base;

namespace HotelAirportService.Domain
{
    public class Airport : HotelAirportServiceBaseEntity
    {
        public string AirportName { get; set; }
        public string AirportShortName { get; set; }
        public int DistanceToAirport { get; set; }
        public TimeSpan TypicalDriveTime { get; set; }
    }
}
