namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeBuilderFactory : IEmailConfirmationTokenIncludeBuilderFactory
{
    public EmailConfirmationTokenIncludeBuilder Create()
    {
        return new EmailConfirmationTokenIncludeBuilder([]);
    }
}
