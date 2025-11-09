namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

public record AddPostCommentCommandResponse(
    string Id,
    string CommentId,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);
