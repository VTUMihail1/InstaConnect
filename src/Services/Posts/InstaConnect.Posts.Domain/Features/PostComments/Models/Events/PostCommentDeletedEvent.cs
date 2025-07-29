namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;

public record PostCommentDeletedEvent(
    string Id,
    string CommentId);
