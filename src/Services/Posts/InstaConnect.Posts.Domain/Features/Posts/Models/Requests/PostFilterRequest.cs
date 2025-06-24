namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostFilterRequest(
    string UserId,
    string UserName,
    string Title);
