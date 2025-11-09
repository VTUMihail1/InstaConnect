namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Utilities;

public abstract class BasePostApplicationIntegrationTest : BasePostWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
