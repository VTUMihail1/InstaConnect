using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IMongoDbContext
{
    public IClientSessionHandle? ClientSessionHandle { get; }

    public IMongoCollection<TEntity> Collection<TEntity>(string name);

    public Task AbortAsync(CancellationToken cancellationToken);

    public Task BeginAsync(CancellationToken cancellationToken);

    public Task CommitAsync(CancellationToken cancellationToken);
}
