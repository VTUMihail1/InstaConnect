using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockFactory
{
	public static IPostLikeIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostLikeIncludeBuilderFactory(new PostLikeIncludeDescriptorFactory());
	}
}
