using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCollection : IMongoDbCollection<PostCommentLike>
{
	public IPostCommentLikeFluent AggregateFluent();

	public Task DeleteAsync(
		PostCommentLike entity,
		CancellationToken cancellationToken);
}
