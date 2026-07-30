using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Helpers;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostCommentEventClient CreatePostCommentEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new PostCommentEventClient(eventHarness);
		}
	}
}
