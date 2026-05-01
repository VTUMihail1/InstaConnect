using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Common.Infrastructure.Features.Data.Helpers;

public abstract class MongoDbContext : IMongoDbContext
{
	private readonly IMongoClient _mongoClient;
	private readonly IMongoDatabase _mongoDatabase;

	private IClientSessionHandle? _clientSessionHandle;

	protected MongoDbContext(
		IMongoClient mongoClient,
		IMongoDatabase mongoDatabase)
	{
		_mongoClient = mongoClient;
		_mongoDatabase = mongoDatabase;
	}

	public IClientSessionHandle? ClientSessionHandle => _clientSessionHandle;

	public IMongoCollection<TEntity> ToCollection<TEntity, TKey>(string name)
		where TEntity : IEntityWithId<TKey>
		where TKey : IEntityId
	{
		return _mongoDatabase.GetCollection<TEntity>(name);
	}

	public async Task BeginAsync(CancellationToken cancellationToken)
	{
		_clientSessionHandle = await _mongoClient.StartSessionAsync(null, cancellationToken);
		_clientSessionHandle.StartTransaction();
	}

	public async Task CommitAsync(CancellationToken cancellationToken)
	{
		if (_clientSessionHandle.IsNotInTransaction())
		{
			return;
		}

		await _clientSessionHandle!.CommitTransactionAsync(cancellationToken);
	}

	public async Task AbortAsync(CancellationToken cancellationToken)
	{
		if (_clientSessionHandle.IsNotInTransaction())
		{
			return;
		}

		await _clientSessionHandle!.AbortTransactionAsync(cancellationToken);
	}
}
