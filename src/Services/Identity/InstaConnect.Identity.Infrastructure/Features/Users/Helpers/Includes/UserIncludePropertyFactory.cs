namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;
internal class UserIncludePropertyFactory : IUserIncludePropertyFactory
{
    private readonly IEnumerable<IUserIncludeProperty> _includeProperty;

    public UserIncludePropertyFactory(IEnumerable<IUserIncludeProperty> includeProperty)
    {
        _includeProperty = includeProperty;
    }

    public IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _includeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
