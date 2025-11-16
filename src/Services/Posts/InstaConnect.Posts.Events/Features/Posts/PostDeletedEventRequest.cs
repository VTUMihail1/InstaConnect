namespace InstaConnect.Posts.Events.Features.Posts;

public record PostDeletedEventRequest(PostIdEventPayload Id)
    : IEventRequest;
