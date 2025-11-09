namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Utilities;

public abstract class BasePostCommentLikeApplicationIntegrationTest : BasePostCommentLikeWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostCommentLikeApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
