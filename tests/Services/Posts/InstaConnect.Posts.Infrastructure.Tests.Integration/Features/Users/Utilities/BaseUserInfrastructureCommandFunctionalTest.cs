namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandFunctionalTest : BaseUserWebTest
{
	protected BaseUserInfrastructureCommandFunctionalTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
	}
}
