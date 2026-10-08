using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeCollection : IMongoDbCollection<PostLike>
{
	public IPostLikeFluent AggregateFluent();

	public Task DeleteAsync(
		PostLike entity,
		CancellationToken cancellationToken);
}
