namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Builders;

public class VerifyEmailConfirmationTokenCommandRequestBuilderFactory
{
	public VerifyEmailConfirmationTokenCommandRequestBuilder Create(EmailConfirmationToken emailConfirmationToken)
	{
		return new(emailConfirmationToken);
	}
}
