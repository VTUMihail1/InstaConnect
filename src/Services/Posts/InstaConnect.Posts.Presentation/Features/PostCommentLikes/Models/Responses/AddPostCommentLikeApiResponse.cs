namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;

public record AddPostCommentLikeApiResponse(string Id, string CommentId, string UserId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
