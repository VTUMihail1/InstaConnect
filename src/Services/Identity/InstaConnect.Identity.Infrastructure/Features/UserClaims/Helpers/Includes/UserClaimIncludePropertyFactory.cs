namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Includes;
internal class UserClaimIncludePropertyFactory : IUserClaimIncludePropertyFactory
{
    private readonly IEnumerable<IUserClaimIncludeProperty> _userClaimIncludeProperty;

    public UserClaimIncludePropertyFactory(IEnumerable<IUserClaimIncludeProperty> userClaimIncludeProperty)
    {
        _userClaimIncludeProperty = userClaimIncludeProperty;
    }

    public IEnumerable<IUserClaimIncludeProperty> Create(ICollection<UserClaimIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _userClaimIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserClaimIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
