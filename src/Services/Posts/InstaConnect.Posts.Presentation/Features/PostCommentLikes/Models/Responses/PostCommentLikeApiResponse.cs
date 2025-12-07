namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeApiResponse(string Id, string CommentId, UserApiResponse User, DateTimeOffset CreatedAtUtc);
