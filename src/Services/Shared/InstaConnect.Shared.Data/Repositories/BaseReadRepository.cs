using InstaConnect.Shared.Data.Abstractions;
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
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);

        return entity;
    }

    protected virtual IQueryable<TEntity> IncludeProperties(IQueryable<TEntity> queryable)
    {
        return queryable;
    }
}
