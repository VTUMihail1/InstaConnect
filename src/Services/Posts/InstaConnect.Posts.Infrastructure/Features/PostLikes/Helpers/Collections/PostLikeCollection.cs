using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

public class PostLikeCollection : MongoDbCollection<PostLike>, IPostLikeCollection
{
	private readonly IPostLikeFluentFactory _fluentFactory;

	public PostLikeCollection(
		ISessionHandler sessionHandler,
		IPostLikeFluentFactory fluentFactory,
		IMongoCollection<PostLike> collection) : base(sessionHandler, collection)
	{
		_fluentFactory = fluentFactory;
	}

	public IPostLikeFluent AggregateFluent()
	{
		var fluent = AggregateWithIgnoreCaseCollation();

		return _fluentFactory.Create(fluent);
	}

	public async Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken)
	{
		await DeleteAsync(entity.Id.GetFilter(), cancellationToken);
	}
}
