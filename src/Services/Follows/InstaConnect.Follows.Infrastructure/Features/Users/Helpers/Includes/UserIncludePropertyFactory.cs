namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includes;
internal class UserIncludePropertyFactory : IUserIncludePropertyFactory
{
    private readonly IEnumerable<IUserIncludeProperty> _followIncludeProperties;

    public UserIncludePropertyFactory(IEnumerable<IUserIncludeProperty> followIncludeProperties)
    {
        _followIncludeProperties = followIncludeProperties;
    }

    public IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _followIncludeProperties.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
