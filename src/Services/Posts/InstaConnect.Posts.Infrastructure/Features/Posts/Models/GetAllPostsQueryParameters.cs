namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllPostsQueryParameters(
    string UserId,
    string UserName,
    string Title,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
