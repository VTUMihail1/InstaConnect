using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        private readonly DbContext _dbContext;

        protected Repository(DbContext dbContext)
        {
			_dbContext = dbContext;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, int skipAmount = default, int takeAmount = int.MaxValue)
        {
            var entities = await _dbContext
				.Set<TEntity>()
                .Where(expression)
                .Skip(skipAmount)
                .Take(takeAmount)
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public virtual async Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return entity!;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
