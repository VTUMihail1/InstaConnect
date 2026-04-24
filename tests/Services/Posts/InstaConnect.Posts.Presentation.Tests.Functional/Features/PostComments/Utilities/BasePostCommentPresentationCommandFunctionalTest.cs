namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Utilities;

public abstract class BasePostCommentPresentationCommandFunctionalTest : BasePostCommentWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostCommentPresentationCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
