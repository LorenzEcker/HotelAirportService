using HotelAirportService.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAirportService.Domain
{
    public class Flight : HotelAirportServiceBaseEntity
    {
        public ICollection<Ride> Rides { get; set; }
    }
}
