using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeQueryBuilderFactory : IEmailConfirmationTokenIncludeQueryBuilderFactory
{
    public EmailConfirmationTokenIncludeQueryBuilder Create()
    {
        return new EmailConfirmationTokenIncludeQueryBuilder([]);
    }
}
