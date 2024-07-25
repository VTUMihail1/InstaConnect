using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Shared.Data.Abstract;

public interface IBaseReadRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<PaginationList<TEntity>> GetAllAsync(CollectionReadQuery collectionReadQuery, CancellationToken cancellationToken);

    Task<PaginationList<TEntity>> GetAllFilteredAsync(FilteredCollectionReadQuery<TEntity> filteredCollectionReadQuery, CancellationToken cancellationToken);
}
