namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserMockFactory
{
	public static IUserCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserCommandService>();
	}
}
