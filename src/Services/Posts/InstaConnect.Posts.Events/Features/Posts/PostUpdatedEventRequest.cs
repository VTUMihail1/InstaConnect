namespace InstaConnect.Posts.Events.Features.Posts;

public record PostUpdatedEventRequest(
        PostIdEventPayload Id,
        string Title,
        string Content,
        UserIdEventPayload UserId)
    : IEventRequest;
