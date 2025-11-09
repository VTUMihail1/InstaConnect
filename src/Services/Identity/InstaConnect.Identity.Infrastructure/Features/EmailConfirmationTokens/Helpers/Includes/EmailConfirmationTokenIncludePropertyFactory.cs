namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includes;
internal class EmailConfirmationTokenIncludePropertyFactory : IEmailConfirmationTokenIncludePropertyFactory
{
    private readonly IEnumerable<IEmailConfirmationTokenIncludeProperty> _emailConfirmationTokenIncludeProperty;

    public EmailConfirmationTokenIncludePropertyFactory(IEnumerable<IEmailConfirmationTokenIncludeProperty> emailConfirmationTokenIncludeProperty)
    {
        _emailConfirmationTokenIncludeProperty = emailConfirmationTokenIncludeProperty;
    }

    public IEnumerable<IEmailConfirmationTokenIncludeProperty> Create(ICollection<EmailConfirmationTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _emailConfirmationTokenIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new EmailConfirmationTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
