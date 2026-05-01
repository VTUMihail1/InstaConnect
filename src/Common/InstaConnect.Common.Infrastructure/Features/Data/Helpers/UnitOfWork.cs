using InstaConnect.Common.Application.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Data.Helpers;

internal class UnitOfWork : IUnitOfWork
{
	private readonly IMongoDbContext _mongoDbContext;
	private readonly MassTransit.MongoDbIntegration.MongoDbContext _massTransitMongoDbContext;

	public UnitOfWork(IMongoDbContext mongoDbContext, MassTransit.MongoDbIntegration.MongoDbContext massTransitMongoDbContext)
	{
		_mongoDbContext = mongoDbContext;
		_massTransitMongoDbContext = massTransitMongoDbContext;
	}

	public async Task BeginAsync(CancellationToken cancellationToken)
	{
		await _mongoDbContext.BeginAsync(cancellationToken);
		await _massTransitMongoDbContext.BeginTransaction(cancellationToken);
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		await _mongoDbContext.CommitAsync(cancellationToken);
		await _massTransitMongoDbContext.CommitTransaction(cancellationToken);
	}

	public async Task AbortAsync(CancellationToken cancellationToken)
	{
		await _mongoDbContext.AbortAsync(cancellationToken);
		await _massTransitMongoDbContext.AbortTransaction(cancellationToken);
	}

}
