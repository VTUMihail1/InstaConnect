namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerIntegrationTest : BaseUserWebTest
{
	protected BaseUserInfrastructureEventHandlerIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
