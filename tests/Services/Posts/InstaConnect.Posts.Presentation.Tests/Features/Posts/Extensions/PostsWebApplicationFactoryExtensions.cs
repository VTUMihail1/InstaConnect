using InstaConnect.Posts.Presentation.Tests.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Extensions;

public static class PostsWebApplicationFactoryExtensions
{
	extension(PostsWebApplicationFactory webApplicationFactory)
	{
		public IPostClient CreatePostClient()
		{
			return new PostClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
