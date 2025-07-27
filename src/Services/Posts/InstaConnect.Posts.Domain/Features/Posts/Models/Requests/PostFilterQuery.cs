namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostFilterQuery(
    string UserId,
    string UserName,
    string Title);
