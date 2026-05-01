using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationCommandFunctionalTest : BaseUserClaimWebTest
{
	protected IUserClaimClient Client { get; }

	protected BaseUserClaimPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateUserClaimClient();
	}
}
