namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryIntegrationTest : BaseUserClaimWebTest
{
	protected UserClaimController Controller { get; }

	protected BaseUserClaimPresentationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserClaimController();
	}
}
