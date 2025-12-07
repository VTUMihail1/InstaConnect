namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeDeletedEventRequest(
        string Id,
        string UserId)
    : IEventRequest;
