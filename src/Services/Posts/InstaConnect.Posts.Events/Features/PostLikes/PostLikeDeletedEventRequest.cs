namespace InstaConnect.Posts.Events.Features.PostLikes;

public record PostLikeDeletedEventRequest(PostLikeIdEventPayload Id)
    : IEventRequest;
