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
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomNumber { get; set; }
        public bool HasFreeTransfer { get; set; }
        public Customer Customer { get; set; }
    }
}
