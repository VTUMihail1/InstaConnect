namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Utilities;

public abstract class BasePostLikeApplicationIntegrationTest : BasePostLikeWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostLikeApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
