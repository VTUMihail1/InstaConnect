using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class DeleteUserClaimCommandRepositoryIntegrationTests : BaseUserClaimInfrastructureCommandIntegrationTest
{
	public DeleteUserClaimCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserClaim_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(UserClaim, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaim.Id, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}
}
