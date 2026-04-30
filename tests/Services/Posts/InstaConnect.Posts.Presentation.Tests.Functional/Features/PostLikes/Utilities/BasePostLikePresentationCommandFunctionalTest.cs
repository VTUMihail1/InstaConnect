using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandFunctionalTest : BasePostLikeWebTest
{
	protected IPostLikeClient Client { get; }

	protected BasePostLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreatePostLikeClient();
	}
}
