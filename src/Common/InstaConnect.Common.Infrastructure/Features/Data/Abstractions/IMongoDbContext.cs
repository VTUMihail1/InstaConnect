using InstaConnect.Common.Domain.Features.Entities.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface IMongoDbContext
{
    public IClientSessionHandle? ClientSessionHandle { get; }

    public IMongoCollection<TEntity> ToCollection<TEntity, TKey>(string name)
        where TEntity : IEntityWithId<TKey>
        where TKey : IEntityId;

    public Task AbortAsync(CancellationToken cancellationToken);

    public Task BeginAsync(CancellationToken cancellationToken);

    public Task CommitAsync(CancellationToken cancellationToken);
}
