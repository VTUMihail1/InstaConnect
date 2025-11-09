namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeQueryBuilder
{
    private readonly ICollection<EmailConfirmationTokenIncludeProperty> _includeProperties;

    internal EmailConfirmationTokenIncludeQueryBuilder(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public EmailConfirmationTokenIncludeQuery Build()
    {
        return new EmailConfirmationTokenIncludeQuery(_includeProperties);
    }
}
