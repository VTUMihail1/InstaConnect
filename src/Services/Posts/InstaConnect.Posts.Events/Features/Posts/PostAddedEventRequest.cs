namespace InstaConnect.Posts.Events.Features.Posts;

public record PostAddedEventRequest(
        PostIdEventPayload Id,
        string Title,
        string Content,
        UserIdEventPayload UserId)
    : IEventRequest;
