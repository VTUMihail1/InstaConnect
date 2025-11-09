namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Includes;
internal class ForgotPasswordTokenIncludePropertyFactory : IForgotPasswordTokenIncludePropertyFactory
{
    private readonly IEnumerable<IForgotPasswordTokenIncludeProperty> _forgotPasswordTokenIncludeProperty;

    public ForgotPasswordTokenIncludePropertyFactory(IEnumerable<IForgotPasswordTokenIncludeProperty> forgotPasswordTokenIncludeProperty)
    {
        _forgotPasswordTokenIncludeProperty = forgotPasswordTokenIncludeProperty;
    }

    public IEnumerable<IForgotPasswordTokenIncludeProperty> Create(ICollection<ForgotPasswordTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _forgotPasswordTokenIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ForgotPasswordTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
