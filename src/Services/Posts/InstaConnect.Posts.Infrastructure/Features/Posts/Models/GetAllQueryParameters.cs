namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record GetAllQueryParameters(
    string UserId,
    string UserName,
    string Title,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
