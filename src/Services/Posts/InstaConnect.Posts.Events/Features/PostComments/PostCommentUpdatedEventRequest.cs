namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentUpdatedEventRequest(
        PostCommentIdEventPayload Id,
        string Content,
        UserIdEventPayload UserId)
    : IEventRequest;
