namespace InstaConnect.Posts.Events.Features.PostCommentLikes;

public record PostCommentLikeDeletedEventRequest(PostCommentLikeIdEventPayload Id)
    : IEventRequest;
