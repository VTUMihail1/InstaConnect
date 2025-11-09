namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Includes;
internal class UserIncludePropertyFactory : IUserIncludePropertyFactory
{
    private readonly IEnumerable<IUserIncludeProperty> _chatIncludeProperties;

    public UserIncludePropertyFactory(IEnumerable<IUserIncludeProperty> chatIncludeProperties)
    {
        _chatIncludeProperties = chatIncludeProperties;
    }

    public IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _chatIncludeProperties.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
