using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Base;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Shared.Data.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
{
    private readonly BaseDbContext _baseDbContext;

    protected BaseRepository(BaseDbContext baseDbContext)
    {
        _baseDbContext = baseDbContext;
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync(CollectionQuery collectionQuery, CancellationToken cancellationToken)
    {
        var entities = await IncludeProperties(
            _baseDbContext.Set<TEntity>())
            .OrderEntities(collectionQuery.SortOrder, collectionQuery.SortPropertyName)
            .Skip(collectionQuery.Offset)
            .Take(collectionQuery.Limit)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public virtual async Task<ICollection<TEntity>> GetAllFilteredAsync(FilteredCollectionQuery<TEntity> filteredCollectionQuery, CancellationToken cancellationToken)
    {
        var entities = await IncludeProperties(
            _baseDbContext.Set<TEntity>())
            .Where(filteredCollectionQuery.Expression)
            .OrderEntities(filteredCollectionQuery.SortOrder, filteredCollectionQuery.SortPropertyName)
            .Skip(filteredCollectionQuery.Offset)
            .Take(filteredCollectionQuery.Limit)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public virtual async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var entity =
            await IncludeProperties(
            _baseDbContext.Set<TEntity>())
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _baseDbContext.Set<TEntity>().Add(entity);
        await _baseDbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
    {
        _baseDbContext.Set<TEntity>().AddRange(entities);
        await _baseDbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _baseDbContext.Set<TEntity>().Update(entity);
        await _baseDbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
    {
        _baseDbContext.Set<TEntity>().UpdateRange(entities);
        await _baseDbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _baseDbContext.Set<TEntity>().Remove(entity);
        await _baseDbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken)
    {
        _baseDbContext.Set<TEntity>().RemoveRange(entities);
        await _baseDbContext.SaveChangesAsync(cancellationToken);
    }

    protected virtual IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> queryable)
    {
        return queryable;
    }
}
