namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserIncludeProperty : IIncludeProperty<User>
{
    public UserIncludeProperty IncludeProperty { get; }
}
