namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentFilterQuery(
    PostId Id,
    Name UserName);
