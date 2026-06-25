namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

public static class UserDomainMockFactory
{
	public static IUserFactory CreateFactory()
	{
		return Mocker.Mock<IUserFactory>();
	}

	public static IUserCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IUserCommandRepository>();
	}
}
