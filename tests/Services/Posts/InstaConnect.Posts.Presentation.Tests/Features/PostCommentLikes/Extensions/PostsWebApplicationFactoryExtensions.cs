using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostCommentLikeClient CreatePostCommentLikeClient()
		{
			return new PostCommentLikeClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
