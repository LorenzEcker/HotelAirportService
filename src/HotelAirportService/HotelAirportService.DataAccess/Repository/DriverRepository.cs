using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;

namespace HotelAirportService.DataAccess.repository
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository(HotelAirportServiceContext dbContext) : base(dbContext)
        {
        }
    }
}
