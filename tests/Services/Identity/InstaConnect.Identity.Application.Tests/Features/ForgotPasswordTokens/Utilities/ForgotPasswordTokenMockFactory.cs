namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMockFactory
{
	public static IForgotPasswordTokenCommandService CreateCommandService()
	{
		return Mocker.Mock<IForgotPasswordTokenCommandService>();
	}
}
