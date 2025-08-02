namespace InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;

public record UpdatePostCommentApiResponse(string Id, string CommentId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
