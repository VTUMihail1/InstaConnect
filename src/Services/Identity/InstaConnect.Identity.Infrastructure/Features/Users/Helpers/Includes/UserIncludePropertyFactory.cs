namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;
internal class UserIncludePropertyFactory : IUserIncludePropertyFactory
{
    private readonly IEnumerable<IUserIncludeProperty> _userIncludeProperty;

    public UserIncludePropertyFactory(IEnumerable<IUserIncludeProperty> userIncludeProperty)
    {
        _userIncludeProperty = userIncludeProperty;
    }

    public IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _userIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
