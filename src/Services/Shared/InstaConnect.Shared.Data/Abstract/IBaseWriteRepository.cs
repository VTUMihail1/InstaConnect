using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Shared.Data.Abstract;
public interface IBaseWriteRepository<TEntity> where TEntity : class, IBaseEntity
{
    void Add(TEntity entity);
    void AddRange(ICollection<TEntity> entities);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(TEntity entity);
    void DeleteRange(ICollection<TEntity> entities);
    Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<ICollection<TEntity>> GetAllFilteredAsync(FilteredCollectionWriteQuery<TEntity> filteredCollectionWriteQuery, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(TEntity entity);
    void UpdateRange(ICollection<TEntity> entities);
}
