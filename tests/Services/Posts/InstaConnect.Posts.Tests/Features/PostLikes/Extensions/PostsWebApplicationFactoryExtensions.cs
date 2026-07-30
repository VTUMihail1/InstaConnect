using InstaConnect.Posts.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostLikes.Helpers;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostLikeEventClient CreateLikeEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new PostLikeEventClient(eventHarness);
		}
	}
}
