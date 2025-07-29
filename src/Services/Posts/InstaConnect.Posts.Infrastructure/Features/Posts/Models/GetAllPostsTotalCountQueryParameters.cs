namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllPostsTotalCountQueryParameters(
    string UserId,
    string UserName,
    string Title);
