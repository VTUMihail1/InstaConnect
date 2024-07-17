using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Shared.Data.Abstract;

public interface IBaseReadRepository<TEntity> where TEntity : class, IBaseEntity
{
    void Add(TEntity entity);

    void Delete(TEntity entity);

    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<PaginationList<TEntity>> GetAllAsync(CollectionReadQuery collectionReadQuery, CancellationToken cancellationToken);

    void Update(TEntity entity);

    Task<PaginationList<TEntity>> GetAllFilteredAsync(FilteredCollectionReadQuery<TEntity> filteredCollectionReadQuery, CancellationToken cancellationToken);

    void AddRange(ICollection<TEntity> entities);

    void UpdateRange(ICollection<TEntity> entities);

    void DeleteRange(ICollection<TEntity> entities);

    Task<bool> AnyAsync(CancellationToken cancellationToken);
}
