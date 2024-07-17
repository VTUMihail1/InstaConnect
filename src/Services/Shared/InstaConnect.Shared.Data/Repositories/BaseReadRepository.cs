using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Shared.Data.Repositories;

public abstract class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : class, IBaseEntity
{
    private readonly DbContext _dbContext;

    protected BaseReadRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<PaginationList<TEntity>> GetAllAsync(CollectionReadQuery collectionReadQuery, CancellationToken cancellationToken)
    {
        var entities = await IncludeProperties(
            _dbContext.Set<TEntity>())
            .OrderEntities(collectionReadQuery.SortOrder, collectionReadQuery.SortPropertyName)
            .ToPagedList(collectionReadQuery.Page, collectionReadQuery.PageSize, cancellationToken);

        return entities;
    }

    public virtual async Task<PaginationList<TEntity>> GetAllFilteredAsync(FilteredCollectionReadQuery<TEntity> filteredCollectionReadQuery, CancellationToken cancellationToken)
    {
        var entities = await IncludeProperties(
            _dbContext.Set<TEntity>())
            .Where(filteredCollectionReadQuery.Expression)
            .OrderEntities(filteredCollectionReadQuery.SortOrder, filteredCollectionReadQuery.SortPropertyName)
            .ToPagedList(filteredCollectionReadQuery.Page, filteredCollectionReadQuery.PageSize, cancellationToken);

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
