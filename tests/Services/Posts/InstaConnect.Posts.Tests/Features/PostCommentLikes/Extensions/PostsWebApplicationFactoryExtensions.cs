using InstaConnect.Posts.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostCommentLikeEventClient CreateCommentLikeEventClient()
		{
			var eventHarness = webApplicationFactory.Services.GetEventHarness();

			return new PostCommentLikeEventClient(eventHarness);
		}
	}
}
