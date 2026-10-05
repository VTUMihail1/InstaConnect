using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

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
}
