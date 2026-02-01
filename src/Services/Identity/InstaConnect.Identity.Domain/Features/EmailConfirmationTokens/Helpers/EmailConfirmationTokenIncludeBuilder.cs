namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeBuilder
{
    private readonly ICollection<EmailConfirmationTokenIncludeProperty> _includeProperties;

    internal EmailConfirmationTokenIncludeBuilder(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public EmailConfirmationTokenInclude Build()
    {
        return new(_includeProperties);
    }
}
