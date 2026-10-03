using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

public class UserCollection : MongoDbCollection<User>, IUserCollection
{
	private readonly IUserFluentFactory _fluentFactory;

	public UserCollection(
		ISessionHandler sessionHandler,
		IUserFluentFactory fluentFactory,
		IMongoCollection<User> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IUserFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await UpdateAsync(entity.Id.GetFilter(), entity, cancellationToken);
	}

	public async Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
