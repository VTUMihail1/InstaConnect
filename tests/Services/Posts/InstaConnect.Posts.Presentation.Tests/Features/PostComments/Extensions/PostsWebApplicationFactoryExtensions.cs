using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostCommentClient CreatePostCommentClient()
		{
			return new PostCommentClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
