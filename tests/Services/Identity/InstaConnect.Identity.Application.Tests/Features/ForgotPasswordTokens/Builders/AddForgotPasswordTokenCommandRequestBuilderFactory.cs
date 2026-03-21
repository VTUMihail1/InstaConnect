namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;

public class AddForgotPasswordTokenCommandRequestBuilderFactory
{
    public AddForgotPasswordTokenCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
