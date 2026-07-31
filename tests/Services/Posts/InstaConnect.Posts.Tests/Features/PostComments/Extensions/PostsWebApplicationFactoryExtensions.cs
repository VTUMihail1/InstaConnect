using InstaConnect.Posts.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Tests.Features.PostComments.Helpers;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostCommentEventClient CreateCommentEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new PostCommentEventClient(eventClient);
		}
	}
}
