namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;

public class VerifyEmailConfirmationTokenCommandBuilderFactory
{
	public VerifyEmailConfirmationTokenCommandBuilder Create(EmailConfirmationToken emailConfirmationToken)
	{
		return new(emailConfirmationToken);
	}
}
