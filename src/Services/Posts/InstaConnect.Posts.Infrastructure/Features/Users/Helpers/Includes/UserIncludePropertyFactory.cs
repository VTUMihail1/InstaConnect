namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Includes;
internal class UserIncludePropertyFactory : IUserIncludePropertyFactory
{
    private readonly IEnumerable<IUserIncludeProperty> _postIncludeProperty;

    public UserIncludePropertyFactory(IEnumerable<IUserIncludeProperty> postIncludeProperty)
    {
        _postIncludeProperty = postIncludeProperty;
    }

    public IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _postIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
