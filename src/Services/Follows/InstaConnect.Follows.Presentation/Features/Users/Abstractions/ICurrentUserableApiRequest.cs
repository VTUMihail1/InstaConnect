namespace InstaConnect.Follows.Presentation.Features.Users.Abstractions;

public interface ICurrentUserableApiRequest
{
    public string CurrentUserId { get; }
}
