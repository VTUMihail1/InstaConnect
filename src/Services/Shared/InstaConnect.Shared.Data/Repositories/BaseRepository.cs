using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Filters;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Shared.Data.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
{
    private readonly DbContext _dbContext;

    protected BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync(CollectionQuery collectionQuery, CancellationToken cancellationToken)
    {
        var entities = await IncludeProperties(
            _dbContext.Set<TEntity>())
            .OrderEntities(collectionQuery.SortOrder, collectionQuery.SortPropertyName)
            .Skip(collectionQuery.Offset)
            .Take(collectionQuery.Limit)
            .ToListAsync(cancellationToken);

        return entities;
    }

    public virtual async Task<ICollection<TEntity>> GetAllFilteredAsync(FilteredCollectionQuery<TEntity> filteredCollectionQuery, CancellationToken cancellationToken)
    {
        var entities = await IncludeProperties(
            _dbContext.Set<TEntity>())
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
            _dbContext.Set<TEntity>())
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public virtual Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = _dbContext
            .Set<TEntity>()
            .AnyAsync(cancellationToken);

        return any;
    }

    public virtual void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public virtual void AddRange(ICollection<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
    }

    public virtual void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public virtual void UpdateRange(ICollection<TEntity> entities)
    {
        _dbContext.Set<TEntity>().UpdateRange(entities);
    }

    public virtual void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public virtual void DeleteRange(ICollection<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
    }

    protected virtual IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> queryable)
    {
        return queryable;
    }
}
