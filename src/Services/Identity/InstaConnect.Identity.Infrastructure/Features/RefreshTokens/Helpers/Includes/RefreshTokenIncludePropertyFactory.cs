namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Includes;
internal class RefreshTokenIncludePropertyFactory : IRefreshTokenIncludePropertyFactory
{
    private readonly IEnumerable<IRefreshTokenIncludeProperty> _refreshTokenIncludeProperty;

    public RefreshTokenIncludePropertyFactory(IEnumerable<IRefreshTokenIncludeProperty> refreshTokenIncludeProperty)
    {
        _refreshTokenIncludeProperty = refreshTokenIncludeProperty;
    }

    public IEnumerable<IRefreshTokenIncludeProperty> Create(ICollection<RefreshTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _refreshTokenIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new RefreshTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
