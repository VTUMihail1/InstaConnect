namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeAddedEventRequest(
        PostLikeIdEventPayload Id,
        DateTimeOffset CreatedAt)
    : IEventRequest;
