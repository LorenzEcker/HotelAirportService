using HotelAirportService.DataAccess.repository.Base;
using HotelAirportService.Domain;

namespace HotelAirportService.DataAccess.repository
{
    public interface IRideRepository : IBaseRepository<Ride>
    {
        Task<List<Ride>> GetRidesForDay(DateOnly today);
    }
}
