namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Builders;

public class AddEmailConfirmationTokenCommandBuilderFactory
{
	public AddEmailConfirmationTokenCommandBuilder Create(User user)
	{
		return new(user);
	}
}
