namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryFilter(
    string UserId,
    string UserName,
    string Title);
