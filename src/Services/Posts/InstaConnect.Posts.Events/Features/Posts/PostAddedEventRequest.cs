namespace InstaConnect.Posts.Events.Features.Posts;

public record PostAddedEventRequest(
        string Id,
        string Title,
        string Content,
        string UserId,
        DateTimeOffset CreatedAtUtc,
        DateTimeOffset UpdatedAtUtc)
    : IEventRequest;
