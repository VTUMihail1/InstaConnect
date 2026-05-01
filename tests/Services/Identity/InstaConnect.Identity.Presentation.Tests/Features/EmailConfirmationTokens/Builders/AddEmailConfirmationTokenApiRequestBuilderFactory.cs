namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;

public class AddEmailConfirmationTokenApiRequestBuilderFactory
{
	public AddEmailConfirmationTokenApiRequestBuilder Create(User user)
	{
		return new(user);
	}
}
