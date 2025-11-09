namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public record UpdatePostCommentCommandResponse(
    string Id,
    string CommentId,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
