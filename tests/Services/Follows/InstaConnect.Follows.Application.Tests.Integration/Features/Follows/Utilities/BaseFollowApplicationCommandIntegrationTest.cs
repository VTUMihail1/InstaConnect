using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowApplicationCommandIntegrationTest : BaseFollowWebTest
{
    protected IApplicationSender Sender { get; }

    protected BaseFollowApplicationCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
