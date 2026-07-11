namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenDomainMockFactory
{
	public static IEmailConfirmationTokenFactory CreateFactory()
	{
		return Mocker.Mock<IEmailConfirmationTokenFactory>();
	}

	public static IEmailConfirmationTokenCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IEmailConfirmationTokenCommandRepository>();
	}

	public static IEmailConfirmationTokenEmailSender CreateEmailSender()
	{
		return Mocker.Mock<IEmailConfirmationTokenEmailSender>();
	}
}
