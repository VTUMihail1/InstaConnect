namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeQueryBuilderFactory : IEmailConfirmationTokenIncludeQueryBuilderFactory
{
    public EmailConfirmationTokenIncludeQueryBuilder Create()
    {
        return new EmailConfirmationTokenIncludeQueryBuilder([]);
    }
}
