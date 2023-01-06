using HotelAirportService.Domain.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
