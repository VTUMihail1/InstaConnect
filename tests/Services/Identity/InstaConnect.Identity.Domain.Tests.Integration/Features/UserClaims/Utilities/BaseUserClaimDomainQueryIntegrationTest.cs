using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimDomainQueryIntegrationTest : BaseUserClaimWebTest
{
	protected IUserClaimQueryService Service { get; }

	protected BaseUserClaimDomainQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetUserClaimQueryService();
	}
}
