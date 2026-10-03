using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Collections;

public class ChatCollection : MongoDbCollection<Chat>, IChatCollection
{
	private readonly IChatFluentFactory _fluentFactory;

	public ChatCollection(
		ISessionHandler sessionHandler,
		IChatFluentFactory fluentFactory,
		IMongoCollection<Chat> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IChatFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
