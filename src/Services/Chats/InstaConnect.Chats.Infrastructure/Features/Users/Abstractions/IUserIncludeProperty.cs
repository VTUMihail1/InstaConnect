namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

public interface IUserIncludeProperty : IIncluder<User>
{
    public UserIncludeProperty IncludeProperty { get; }
}
