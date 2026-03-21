namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;

public class AddForgotPasswordTokenApiRequestBuilderFactory
{
    public AddForgotPasswordTokenApiRequestBuilder Create(User user)
    {
        return new(user);
    }
}
