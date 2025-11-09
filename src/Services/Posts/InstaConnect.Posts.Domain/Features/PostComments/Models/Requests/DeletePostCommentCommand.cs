namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record DeletePostCommentCommand(
    string Id,
    string CommentId,
    string UserId);
