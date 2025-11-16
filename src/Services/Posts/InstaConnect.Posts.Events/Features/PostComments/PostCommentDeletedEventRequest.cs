namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentDeletedEventRequest(PostCommentIdEventPayload Id)
    : IEventRequest;
