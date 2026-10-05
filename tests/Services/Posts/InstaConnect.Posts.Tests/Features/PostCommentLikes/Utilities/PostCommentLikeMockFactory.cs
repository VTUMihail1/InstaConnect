using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockFactory
{
	public static IPostCommentLikeIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostCommentLikeIncludeBuilderFactory(new PostCommentLikeIncludeDescriptorFactory());
	}
}
