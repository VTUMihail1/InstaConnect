namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Builders;

public class AddEmailConfirmationTokenCommandRequestBuilderFactory
{
    public AddEmailConfirmationTokenCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
