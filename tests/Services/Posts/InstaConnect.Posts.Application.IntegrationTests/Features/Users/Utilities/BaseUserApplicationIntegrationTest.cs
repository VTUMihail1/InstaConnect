using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Common.Tests.Features.Utilities;

namespace InstaConnect.Users.Application.IntegrationTests.Features.Users.Utilities;

public abstract class BaseUserApplicationIntegrationTest : BaseUserWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BaseUserApplicationIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
