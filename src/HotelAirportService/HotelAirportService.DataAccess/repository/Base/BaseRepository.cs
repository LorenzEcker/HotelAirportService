using HotelAirportService.DataAccess.context;
using HotelAirportService.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelAirportService.DataAccess.repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : HotelAirportServiceBaseEntity
    {
        protected HotelAirportServiceContext DbContext { get; init; }

        public BaseRepository(HotelAirportServiceContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity?> InsertAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() => DbContext.Set<TEntity>().Add(entity));
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> GetAsync(TEntity entity)
        {
            return await DbContext.Set<TEntity>().FindAsync(entity);
        }

        public async Task<TEntity?> UpdateAsync(TEntity entity)
        {
            TEntity? fetchedEntity = await GetAsync(entity);
            if (fetchedEntity == null)
            {
                return null;
            }
            else
            {
                var e = DbContext.Set<TEntity>().Update(fetchedEntity).Entity;
                await DbContext.SaveChangesAsync();
                return e;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.Factory.StartNew(() =>
                DbContext
                    .Set<TEntity>()
                    .Select(x => x.Id)
                    .Any(e => e == id));
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            if (await ExistsAsync(id))
            {
                TEntity e = await GetByIdAsync(id);
                if (e != null)
                {
                    e.Deleted = true;
                    DbContext.Set<TEntity>().Update(e);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            else return false;
        }

        public async Task<bool> HardDeleteAsync(Guid id)
        {
            if (await ExistsAsync(id))
            {
                DbContext.Set<TEntity>().Remove((await GetByIdAsync(id))!);
                await DbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
