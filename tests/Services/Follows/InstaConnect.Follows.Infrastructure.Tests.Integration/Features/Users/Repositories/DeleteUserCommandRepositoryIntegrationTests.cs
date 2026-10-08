namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}
}
