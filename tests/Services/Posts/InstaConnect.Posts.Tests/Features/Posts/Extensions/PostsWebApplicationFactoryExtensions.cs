using InstaConnect.Posts.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Tests.Features.Posts.Helpers;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostEventClient CreatePostEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new PostEventClient(eventHarness);
		}
	}
}
