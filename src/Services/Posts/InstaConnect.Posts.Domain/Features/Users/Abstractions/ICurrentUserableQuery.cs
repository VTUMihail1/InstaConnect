namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;

public interface ICurrentUserableQuery
{
    public CurrentUserQuery CurrentUser { get; }
}
