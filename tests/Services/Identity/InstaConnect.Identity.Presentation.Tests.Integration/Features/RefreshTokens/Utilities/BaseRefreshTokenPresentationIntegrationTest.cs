namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationIntegrationTest : BaseRefreshTokenWebTest
{
	protected RefreshTokenController Controller { get; }

	protected BaseRefreshTokenPresentationIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetRefreshTokenController();
	}
}
