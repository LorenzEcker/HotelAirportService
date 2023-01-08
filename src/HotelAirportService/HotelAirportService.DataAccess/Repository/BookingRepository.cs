using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;

namespace HotelAirportService.DataAccess.repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelAirportServiceContext dbContext) : base(dbContext)
        {
        }
    }
}
