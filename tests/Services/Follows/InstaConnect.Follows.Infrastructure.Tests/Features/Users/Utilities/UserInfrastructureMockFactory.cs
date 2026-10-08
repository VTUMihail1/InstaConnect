using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

public static class UserInfrastructureMockFactory
{
	public static IUserCollection CreateCollection()
	{
		return Mocker.Mock<IUserCollection>();
	}

	public static IUserFluent CreateFluent()
	{
		return Mocker.Mock<IUserFluent>();
	}

	public static IUserResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IUserResponseFluent>();
	}
}
