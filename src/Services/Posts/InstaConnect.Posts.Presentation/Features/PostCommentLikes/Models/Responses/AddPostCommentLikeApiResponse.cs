namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record AddPostCommentLikeApiResponse(string Id, string CommentId, string UserId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
