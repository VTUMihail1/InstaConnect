using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Extensions;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationCommandFunctionalTest : BasePostCommentLikeWebTest
{
	protected IPostCommentLikeClient Client { get; }

	protected BasePostCommentLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreatePostCommentLikeClient();
	}
}
