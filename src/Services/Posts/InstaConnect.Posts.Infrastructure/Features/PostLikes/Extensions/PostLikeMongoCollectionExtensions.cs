using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

internal static class PostLikeMongoCollectionExtensions
{
	extension(IMongoCollection<PostLike> collection)
	{
		public async Task DeleteAsync(
			IClientSessionHandle? session,
			PostLike entity,
			CancellationToken cancellationToken)
		{
			await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
		}
	}
}
