using HotelAirportService.Domain.Base;

namespace HotelAirportService.DataAccess.repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : HotelAirportServiceBaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> InsertAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(TEntity entity);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> HardDeleteAsync(Guid id);
        Task<bool> SoftDeleteAsync(Guid id);

    }
}
