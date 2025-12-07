namespace InstaConnect.Posts.Events.Features.Posts;

public record PostDeletedEventRequest(string Id)
    : IEventRequest;
