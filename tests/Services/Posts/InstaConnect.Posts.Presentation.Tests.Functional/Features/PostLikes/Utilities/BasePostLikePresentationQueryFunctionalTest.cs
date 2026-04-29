namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationQueryFunctionalTest : BasePostLikeWebTest
{
	protected HttpClient HttpClient { get; }

	protected BasePostLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		HttpClient = webApplicationFactory.CreateClient();
	}
}
