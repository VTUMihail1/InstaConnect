using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeBuilderFactory
{
	public PostLikeIncludeBuilder Create();
}
