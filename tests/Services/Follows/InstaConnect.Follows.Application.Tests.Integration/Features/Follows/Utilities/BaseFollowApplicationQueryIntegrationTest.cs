using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowApplicationQueryIntegrationTest : BaseFollowWebTest
{
    protected IApplicationSender Sender { get; }

    protected BaseFollowApplicationQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        Sender = ServiceScope.GetSender();
    }
}
