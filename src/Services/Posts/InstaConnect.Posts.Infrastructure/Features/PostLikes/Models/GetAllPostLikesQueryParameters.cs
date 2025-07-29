namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record GetAllPostLikesQueryParameters(
    string Id,
    string UserId,
    string UserName,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
