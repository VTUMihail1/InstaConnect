namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeAddedEventRequest(
        string Id,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
