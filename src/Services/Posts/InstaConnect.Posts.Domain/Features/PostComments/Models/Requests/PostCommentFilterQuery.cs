namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentFilterQuery(
    string Id,
    string UserId,
    string UserName);
