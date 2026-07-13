namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;

public class AddForgotPasswordTokenCommandBuilderFactory
{
	public AddForgotPasswordTokenCommandBuilder Create(User user)
	{
		return new(user);
	}
}
