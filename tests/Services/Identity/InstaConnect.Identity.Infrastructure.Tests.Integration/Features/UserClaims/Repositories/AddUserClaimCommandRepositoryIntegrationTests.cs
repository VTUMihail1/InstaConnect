using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Repositories;

public class AddUserClaimCommandRepositoryIntegrationTests : BaseUserClaimInfrastructureCommandIntegrationTest
{
	public AddUserClaimCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUserClaim_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(UserClaim, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaim.Id, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(UserClaim);
	}
}
