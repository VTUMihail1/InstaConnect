using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly InstaConnectContext _instaConnectContext;

        protected Repository(InstaConnectContext instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _instaConnectContext
                .Set<TEntity>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public virtual async Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _instaConnectContext
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return entity;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _instaConnectContext.Set<TEntity>().Add(entity);
            await _instaConnectContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _instaConnectContext.Set<TEntity>().Update(entity);
            await _instaConnectContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _instaConnectContext.Set<TEntity>().Remove(entity);
            await _instaConnectContext.SaveChangesAsync();
        }
    }
}
