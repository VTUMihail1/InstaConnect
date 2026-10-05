using InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class DeleteFollowCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	public DeleteFollowCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Follow, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(Follow.Id, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}
}
