using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureQueryIntegrationTest : BaseFollowWebTest
{
	protected IFollowQueryRepository Repository { get; }

	protected BaseFollowInfrastructureQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetFollowQueryRepository();
	}
}
