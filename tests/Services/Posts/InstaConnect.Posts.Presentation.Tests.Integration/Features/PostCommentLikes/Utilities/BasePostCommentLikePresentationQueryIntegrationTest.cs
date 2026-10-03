namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryIntegrationTest : BasePostCommentLikeWebTest
{
	protected PostCommentLikeController Controller { get; }

	protected UserPostCommentLikeController UserController { get; }

	protected BasePostCommentLikePresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostCommentLikeController();
		UserController = ServiceScope.GetUserPostCommentLikeController();
	}
}
