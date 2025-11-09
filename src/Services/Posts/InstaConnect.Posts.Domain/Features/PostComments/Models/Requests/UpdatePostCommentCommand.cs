namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record UpdatePostCommentCommand(
    string Id,
    string CommentId,
    string UserId,
    string Content);
