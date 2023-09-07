using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly InstaConnectContext _instaConnectContext;

        protected Repository(InstaConnectContext instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllFilteredAsync(Expression<Func<TEntity, bool>> expression)
        {
            var filteredEntities = await _instaConnectContext
                .Set<TEntity>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();

            return filteredEntities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _instaConnectContext
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public async Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _instaConnectContext
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            _instaConnectContext.Set<TEntity>().Add(entity);
            await _instaConnectContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _instaConnectContext.Set<TEntity>().Update(entity);
            await _instaConnectContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _instaConnectContext.Set<TEntity>().Remove(entity);
            await _instaConnectContext.SaveChangesAsync();
        }
    }
}
