namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserIncludeProperty : IIncludeProperty<User>
{
    public UserIncludeProperty IncludeProperty { get; }
}
