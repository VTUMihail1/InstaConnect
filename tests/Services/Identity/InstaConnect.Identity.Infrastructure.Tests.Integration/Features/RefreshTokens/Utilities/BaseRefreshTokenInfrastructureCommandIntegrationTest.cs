using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenInfrastructureCommandIntegrationTest : BaseRefreshTokenWebTest
{
	protected IRefreshTokenCommandRepository Repository { get; }

	protected IRefreshTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseRefreshTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetRefreshTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetRefreshTokenIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
	}
}
