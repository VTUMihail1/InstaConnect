using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Helpers;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostMockFactory
{
	public static IPostIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostIncludeBuilderFactory(new PostIncludeDescriptorFactory());
	}
}
