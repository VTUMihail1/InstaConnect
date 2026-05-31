namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandFunctionalTest : BaseUserWebTest
{
	protected BaseUserInfrastructureCommandFunctionalTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
	}
}
