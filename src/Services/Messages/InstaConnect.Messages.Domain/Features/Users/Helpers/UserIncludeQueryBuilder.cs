using InstaConnect.Users.Domain.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Domain.Features.Users.Helpers;

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

    public UserIncludeQuery Build()
    {
        return new UserIncludeQuery(_includeProperties);
    }
}
