namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Builders;

public class VerifyEmailConfirmationTokenApiRequestBuilderFactory
{
    public VerifyEmailConfirmationTokenApiRequestBuilder Create(EmailConfirmationToken emailConfirmationToken)
    {
        return new(emailConfirmationToken);
    }
}
