namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includes;
internal class RefreshTokenIncludePropertyFactory : IRefreshTokenIncludePropertyFactory
{
    private readonly IEnumerable<IRefreshTokenIncludeProperty> _includeProperty;

    public RefreshTokenIncludePropertyFactory(IEnumerable<IRefreshTokenIncludeProperty> includeProperty)
    {
        _includeProperty = includeProperty;
    }

    public IEnumerable<IRefreshTokenIncludeProperty> Create(ICollection<RefreshTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _includeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new RefreshTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
