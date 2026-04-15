using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDbContext _mongoDbContext;

    public UnitOfWork(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    public async Task BeginAsync(CancellationToken cancellationToken)
    {
        await _mongoDbContext.BeginAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _mongoDbContext.CommitAsync(cancellationToken);
    }

    public async Task AbortAsync(CancellationToken cancellationToken)
    {
        await _mongoDbContext.AbortAsync(cancellationToken);
    }

}
