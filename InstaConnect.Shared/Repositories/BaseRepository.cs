using InstaConnect.Shared.Extensions;
using InstaConnect.Shared.Models.Base;
using InstaConnect.Shared.Models.Filter;
using InstaConnect.Shared.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Shared.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly BaseDbContext _baseDbContext;

        protected BaseRepository(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(Collection collectionQuery)
        {
            var entities = await IncludeProperties(
                _baseDbContext.Set<TEntity>())
                .OrderEntities(collectionQuery.SortOrder, collectionQuery.SortPropertyName)
                .Skip(collectionQuery.Offset)
                .Take(collectionQuery.Limit)
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public virtual async Task<ICollection<TEntity>> GetAllFilteredAsync(FilteredCollection<TEntity> filteredCollectionQuery)
        {
            var entities = await IncludeProperties(
                _baseDbContext.Set<TEntity>())
                .Where(filteredCollectionQuery.Expression)
                .OrderEntities(filteredCollectionQuery.SortOrder, filteredCollectionQuery.SortPropertyName)
                .Skip(filteredCollectionQuery.Offset)
                .Take(filteredCollectionQuery.Limit)
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public virtual async Task<TEntity?> GetByIdAsync(string id)
        {
            var entity =
                await IncludeProperties(
                _baseDbContext.Set<TEntity>())
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _baseDbContext.Set<TEntity>().Add(entity);
            await _baseDbContext.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            _baseDbContext.Set<TEntity>().AddRange(entities);
            await _baseDbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _baseDbContext.Set<TEntity>().Update(entity);
            await _baseDbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(ICollection<TEntity> entities)
        {
            _baseDbContext.Set<TEntity>().UpdateRange(entities);
            await _baseDbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _baseDbContext.Set<TEntity>().Remove(entity);
            await _baseDbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(ICollection<TEntity> entities)
        {
            _baseDbContext.Set<TEntity>().RemoveRange(entities);
            await _baseDbContext.SaveChangesAsync();
        }

        protected virtual IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> queryable)
        {
            return queryable;
        }
    }
}
