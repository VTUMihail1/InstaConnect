namespace InstaConnect.Posts.Events.Features.PostComments;

public record PostCommentDeletedEventRequest(
    string Id,
    string CommentId)
    : IEventRequest;
