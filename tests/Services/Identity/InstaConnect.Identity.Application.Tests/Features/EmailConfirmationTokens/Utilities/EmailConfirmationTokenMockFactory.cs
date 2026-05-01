namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMockFactory
{
	public static IEmailConfirmationTokenCommandService CreateCommandService()
	{
		return Mocker.Mock<IEmailConfirmationTokenCommandService>();
	}
}
