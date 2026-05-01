namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

public class ForgotPasswordTokenBuilderFactory
{
	public ForgotPasswordTokenBuilder Create(User user)
	{
		return new(user);
	}
}
