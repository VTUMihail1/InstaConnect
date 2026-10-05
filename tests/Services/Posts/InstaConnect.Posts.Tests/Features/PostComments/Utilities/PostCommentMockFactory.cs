using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentMockFactory
{
	public static IPostCommentIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostCommentIncludeBuilderFactory(new PostCommentIncludeDescriptorFactory());
	}
}
