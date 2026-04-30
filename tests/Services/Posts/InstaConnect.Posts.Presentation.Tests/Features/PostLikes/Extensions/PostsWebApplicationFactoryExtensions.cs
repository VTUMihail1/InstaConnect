using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostLikeClient CreatePostLikeClient()
		{
			return new PostLikeClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
