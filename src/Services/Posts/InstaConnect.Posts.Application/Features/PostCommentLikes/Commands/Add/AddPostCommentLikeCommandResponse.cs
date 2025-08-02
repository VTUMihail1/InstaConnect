namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;

public record AddPostCommentLikeCommandResponse(string Id, string CommentId, string CommentLikeId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
