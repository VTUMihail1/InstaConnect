namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includes;
internal class ForgotPasswordTokenIncludePropertyFactory : IForgotPasswordTokenIncludePropertyFactory
{
    private readonly IEnumerable<IForgotPasswordTokenIncludeProperty> _includeProperty;

    public ForgotPasswordTokenIncludePropertyFactory(IEnumerable<IForgotPasswordTokenIncludeProperty> includeProperty)
    {
        _includeProperty = includeProperty;
    }

    public IEnumerable<IForgotPasswordTokenIncludeProperty> Create(ICollection<ForgotPasswordTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _includeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ForgotPasswordTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
