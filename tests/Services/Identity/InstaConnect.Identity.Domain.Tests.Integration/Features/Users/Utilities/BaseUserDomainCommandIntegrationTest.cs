using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserDomainCommandIntegrationTest : BaseUserWebTest
{
	protected IUserCommandService Service { get; }

	protected BaseUserDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetCommandService();
	}
}
