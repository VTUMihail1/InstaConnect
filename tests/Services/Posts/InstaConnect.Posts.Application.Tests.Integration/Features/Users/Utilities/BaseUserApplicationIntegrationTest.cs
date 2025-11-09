namespace InstaConnect.Posts.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationIntegrationTest : BaseUserWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BaseUserApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
