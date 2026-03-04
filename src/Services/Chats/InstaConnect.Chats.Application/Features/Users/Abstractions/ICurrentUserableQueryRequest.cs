namespace InstaConnect.Chats.Application.Features.Users.Abstractions;

public interface ICurrentUserableQueryRequest
{
    public string CurrentUserId { get; }
}
