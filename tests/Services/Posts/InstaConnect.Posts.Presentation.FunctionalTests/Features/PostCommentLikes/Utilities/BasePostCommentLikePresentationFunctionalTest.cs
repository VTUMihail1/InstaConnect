using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikePresentationFunctionalTest : BasePostCommentLikeWebTest
{
    protected HttpClient HttpClient { get; }

    protected BasePostCommentLikePresentationFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }
}
