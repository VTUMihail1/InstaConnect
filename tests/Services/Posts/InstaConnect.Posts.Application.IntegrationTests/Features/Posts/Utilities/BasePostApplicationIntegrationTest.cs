using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;

public abstract class BasePostApplicationIntegrationTest : BasePostWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
