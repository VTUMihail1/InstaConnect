namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record AddPostCommentApiResponse(string Id, string CommentId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
