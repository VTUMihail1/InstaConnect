namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class UserIncludeQueryBuilder
{
    private readonly ICollection<UserIncludeProperty> _includeProperties;

    internal UserIncludeQueryBuilder(ICollection<UserIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public UserIncludeQueryBuilder WithChats()
    {
        _includeProperties.Add(UserIncludeProperty.Chats);

        return this;
    }

    public UserIncludeQueryBuilder WithChatMessages()
    {
        _includeProperties.Add(UserIncludeProperty.ChatMessages);

        return this;
    }

    public CommonInclude<UserIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
