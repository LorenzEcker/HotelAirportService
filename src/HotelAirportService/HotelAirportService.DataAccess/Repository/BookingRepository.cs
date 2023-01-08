using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelAirportService.DataAccess.repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelAirportServiceContext dbContext) : base(dbContext)
        {
        }

        public Booking? GetBookingByBookingId(string bookingCode)
        {
            var res = DbContext.Booking.Include(b => b.Customer).SingleOrDefault(b => b.BookingCode == bookingCode);
            return res;
        }
    }
}
