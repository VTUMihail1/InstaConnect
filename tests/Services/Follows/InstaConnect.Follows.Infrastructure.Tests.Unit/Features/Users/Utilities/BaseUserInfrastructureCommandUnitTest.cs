using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandUnitTest : BaseUserTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandUnitTest()
	{
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		Collection = UserInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = UserMockFactory.CreateIncludeBuilderFactory();
	}
}
