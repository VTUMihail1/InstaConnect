using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Repositories;

public class AddRefreshTokenCommandRepositoryIntegrationTests : BaseRefreshTokenInfrastructureCommandIntegrationTest
{
	public AddRefreshTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddRefreshToken_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(RefreshToken, CancellationToken);
		var refreshToken = await ServiceScope.GetByIdAsync(RefreshToken.Id, CancellationToken);

		// Assert
		refreshToken.ShouldSatisfy(RefreshToken);
	}
}
