namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;

public record DeletePostCommentLikeCommandRequest(
    string Id,
    string CommentId,
    string UserId) : ICommandRequest;
