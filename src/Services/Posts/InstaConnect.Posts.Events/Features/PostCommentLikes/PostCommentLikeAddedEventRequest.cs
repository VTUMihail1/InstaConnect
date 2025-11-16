namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeAddedEventRequest(
        PostCommentLikeIdEventPayload Id,
        DateTimeOffset CreatedAt)
    : IEventRequest;
