namespace InstaConnect.Posts.Events.Features.Posts;

public record PostUpdatedEventRequest(
        string Id,
        string Title,
        string Content,
        string UserId,
        DateTimeOffset UpdatedAtUtc)
    : IEventRequest;
