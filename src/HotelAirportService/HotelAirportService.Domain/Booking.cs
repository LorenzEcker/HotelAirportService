using HotelAirportService.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAirportService.Domain
{
    public class Booking : HotelAirportServiceBaseEntity
    {
        public string BookingCode { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomNumber { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
