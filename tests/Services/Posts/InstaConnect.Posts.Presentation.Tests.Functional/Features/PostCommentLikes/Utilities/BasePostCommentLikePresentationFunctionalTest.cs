namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationFunctionalTest : BasePostCommentLikeWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostCommentLikePresentationFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
