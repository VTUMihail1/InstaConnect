namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowerQueryParameters(
    string FollowerId,
    string FollowingName,
    string SortOrder,
    string SortProperty,
    int Offset,
    int Limit);
