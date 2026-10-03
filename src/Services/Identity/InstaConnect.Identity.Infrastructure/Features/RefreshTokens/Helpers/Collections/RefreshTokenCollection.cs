using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

public class RefreshTokenCollection : MongoDbCollection<RefreshToken>, IRefreshTokenCollection
{
	private readonly IRefreshTokenFluentFactory _fluentFactory;

	public RefreshTokenCollection(
		ISessionHandler sessionHandler,
		IRefreshTokenFluentFactory fluentFactory,
		IMongoCollection<RefreshToken> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IRefreshTokenFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		RefreshToken entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
