using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;

namespace HotelAirportService.DataAccess.repository
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Booking? GetBookingByBookingId(string bookingCode);
    }
}
