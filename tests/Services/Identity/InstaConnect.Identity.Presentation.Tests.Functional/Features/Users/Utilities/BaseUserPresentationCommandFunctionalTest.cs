using InstaConnect.Identity.Presentation.Tests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.Users.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandFunctionalTest : BaseUserWebTest
{
	protected IUserClient Client { get; }

	protected BaseUserPresentationCommandFunctionalTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Client = webApplicationFactory.CreateUserClient();
	}
}
