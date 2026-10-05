using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class UpdateRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public UpdateRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateRefreshToken_WhenCommandIsValid()
	{
		// Arrange
		var updatedRefreshToken = RefreshTokenBuilder.WithAlreadyExpiresAtUtc().Build();

		// Act
		await Repository.UpdateAsync(updatedRefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshToken.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(updatedRefreshToken);
	}
}
