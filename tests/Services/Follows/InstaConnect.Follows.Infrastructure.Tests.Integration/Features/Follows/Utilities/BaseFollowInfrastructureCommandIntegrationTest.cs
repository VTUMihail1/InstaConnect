using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureCommandIntegrationTest : BaseFollowWebTest
{
	protected IFollowCommandRepository Repository { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowInfrastructureCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetFollowCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetFollowIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
	}
}
