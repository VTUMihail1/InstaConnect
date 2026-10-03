namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostPresentationQueryIntegrationTest : BasePostWebTest
{
	protected PostController Controller { get; }

	protected UserPostController UserController { get; }

	protected BasePostPresentationQueryIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetPostController();
		UserController = ServiceScope.GetUserPostController();
	}
}
