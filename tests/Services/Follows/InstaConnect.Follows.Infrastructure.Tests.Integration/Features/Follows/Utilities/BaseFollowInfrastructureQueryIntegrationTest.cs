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

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Followers, CancellationToken);
		await ServiceScope.AddRangeAsync(Followings, CancellationToken);
		await OnInitializeAsync();
	}
}
