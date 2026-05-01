namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserMockFactory
{
	public static IUserCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserCommandService>();
	}

	public static IUserQueryService CreateQueryService()
	{
		return Mocker.Mock<IUserQueryService>();
	}
}
