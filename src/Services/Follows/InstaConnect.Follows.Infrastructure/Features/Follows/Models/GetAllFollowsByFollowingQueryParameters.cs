namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowingQueryParameters(
    string FollowingId,
    string FollowerName,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
