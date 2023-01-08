using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;

namespace HotelAirportService.DataAccess.repository
{
    public class RideRepository : BaseRepository<Ride>, IRideRepository
    {
        public RideRepository(HotelAirportServiceContext dbContext) : base(dbContext)
        {
        }
    }
}
