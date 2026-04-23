using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationQueryFunctionalTest : BasePostCommentLikeWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostCommentLikePresentationQueryFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
