using HotelAirportService.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAirportService.Domain
{
    public class Driver : HotelAirportServiceBaseEntity
    {
        public string DriverName { get; set; }
        public ICollection<Ride> Rides { get; set; }

    }
}
