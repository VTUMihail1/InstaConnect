namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockFactory
{
	public static IUserClaimCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserClaimCommandService>();
	}

	public static IUserClaimQueryService CreateQueryService()
	{
		return Mocker.Mock<IUserClaimQueryService>();
	}
}
