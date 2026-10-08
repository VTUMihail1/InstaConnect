using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class DeleteRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public DeleteRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteRefreshToken_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(RefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshToken.Id, CancellationToken);

		// Assert
		refreshToken.ShouldBeNull();
	}
}
