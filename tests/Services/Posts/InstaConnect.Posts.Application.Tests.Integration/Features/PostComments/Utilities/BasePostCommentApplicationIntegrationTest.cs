namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Utilities;

public abstract class BasePostCommentApplicationIntegrationTest : BasePostCommentWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostCommentApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
