namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Includes;
internal class UserClaimIncludePropertyFactory : IUserClaimIncludePropertyFactory
{
    private readonly IEnumerable<IUserClaimIncludeProperty> _includeProperty;

    public UserClaimIncludePropertyFactory(IEnumerable<IUserClaimIncludeProperty> includeProperty)
    {
        _includeProperty = includeProperty;
    }

    public IEnumerable<IUserClaimIncludeProperty> Create(ICollection<UserClaimIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _includeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserClaimIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
