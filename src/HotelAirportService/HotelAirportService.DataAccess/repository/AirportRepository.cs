using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;

namespace HotelAirportService.DataAccess.repository
{
    public class AirportRepository : BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(HotelAirportServiceContext dbContext) : base(dbContext)
        {
        }
    }
}
