using InstaConnect.Posts.Domain.Features.Users.Helpers;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserDomainMockFactory
{
	public static IUserFactory CreateFactory()
	{
		return Mocker.Mock<IUserFactory>();
	}

	public static IUserIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new UserIncludeBuilderFactory(new UserIncludeDescriptorFactory());
	}

	public static IUserCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IUserCommandRepository>();
	}

	public static IUserQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IUserQueryRepository>();
	}
}
