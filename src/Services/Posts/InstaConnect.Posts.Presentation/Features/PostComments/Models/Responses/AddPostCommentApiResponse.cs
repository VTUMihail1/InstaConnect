namespace InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;

public record AddPostCommentApiResponse(string Id, string CommentId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
