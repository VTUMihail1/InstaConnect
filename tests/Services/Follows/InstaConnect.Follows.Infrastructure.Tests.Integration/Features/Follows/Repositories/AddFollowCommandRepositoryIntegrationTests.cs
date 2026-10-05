using InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class AddFollowCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	public AddFollowCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddFollow_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(Follow, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(Follow.Id, CancellationToken);

		// Assert
		follow.ShouldSatisfy(Follow);
	}
}
