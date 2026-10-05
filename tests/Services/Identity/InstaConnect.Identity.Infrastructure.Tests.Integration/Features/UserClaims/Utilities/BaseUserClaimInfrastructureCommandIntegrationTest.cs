using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureCommandIntegrationTest : BaseUserClaimWebTest
{
	protected IUserClaimCommandRepository Repository { get; }

	protected IUserClaimIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserClaimInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetClaimCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetClaimIncludeBuilderFactory();
	}
}
