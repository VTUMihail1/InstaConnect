namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record UpdatePostCommentApiResponse(string Id, string CommentId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
