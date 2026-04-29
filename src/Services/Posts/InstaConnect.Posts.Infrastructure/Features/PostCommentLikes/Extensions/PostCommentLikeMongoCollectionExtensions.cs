using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

internal static class PostCommentLikeMongoCollectionExtensions
{
	extension(IMongoCollection<PostCommentLike> collection)
	{
		public async Task DeleteAsync(
			IClientSessionHandle? session,
			PostCommentLike entity,
			CancellationToken cancellationToken)
		{
			await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
		}
	}
}
