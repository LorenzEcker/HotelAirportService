using HotelAirportService.DataAccess.context;
using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelAirportService.DataAccess.repository
{
    public class RideRepository : BaseRepository<Ride>, IRideRepository
    {
        public RideRepository(HotelAirportServiceContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Ride>> GetRidesForDay(DateOnly today)
        {
           return await DbContext.Ride.Where(r => 
               r.Date >= today.ToDateTime(TimeOnly.MinValue) && 
               r.Date <= today.ToDateTime(TimeOnly.MaxValue)).ToListAsync();
        }
    }
}
