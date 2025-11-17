namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentAddedEventRequest(
        PostCommentIdEventPayload Id,
        string Content,
        UserIdEventPayload UserId)
    : IEventRequest;
