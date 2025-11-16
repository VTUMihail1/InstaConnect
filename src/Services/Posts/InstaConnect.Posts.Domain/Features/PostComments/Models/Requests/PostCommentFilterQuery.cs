namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentFilterQuery(
    PostId Id,
    UserId UserId,
    Name UserName);
