namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includes;
internal class EmailConfirmationTokenIncludePropertyFactory : IEmailConfirmationTokenIncludePropertyFactory
{
    private readonly IEnumerable<IEmailConfirmationTokenIncludeProperty> _includeProperty;

    public EmailConfirmationTokenIncludePropertyFactory(IEnumerable<IEmailConfirmationTokenIncludeProperty> includeProperty)
    {
        _includeProperty = includeProperty;
    }

    public IEnumerable<IEmailConfirmationTokenIncludeProperty> Create(ICollection<EmailConfirmationTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _includeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new EmailConfirmationTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
