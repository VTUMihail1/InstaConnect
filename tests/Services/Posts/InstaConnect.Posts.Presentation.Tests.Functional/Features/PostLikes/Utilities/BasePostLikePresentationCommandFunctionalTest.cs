namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Utilities;

public abstract class BasePostLikePresentationCommandFunctionalTest : BasePostLikeWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostLikePresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
