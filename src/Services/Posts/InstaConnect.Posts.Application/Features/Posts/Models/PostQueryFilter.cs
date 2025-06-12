namespace InstaConnect.Posts.Domain.Features.Posts.Models;

public record PostQueryFilter(
    string UserId,
    string UserName,
    string Title);
