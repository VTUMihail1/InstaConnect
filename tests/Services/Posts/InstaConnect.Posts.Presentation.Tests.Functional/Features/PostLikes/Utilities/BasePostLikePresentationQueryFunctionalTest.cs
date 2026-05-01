using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryFunctionalTest : BasePostLikeWebTest
{
	protected IPostLikeClient Client { get; }

	protected BasePostLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreatePostLikeClient();
	}
}
