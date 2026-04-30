using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryFunctionalTest : BaseUserClaimWebTest
{
	protected IUserClaimClient Client { get; }

	protected BaseUserClaimPresentationQueryFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateUserClaimClient();
	}
}
