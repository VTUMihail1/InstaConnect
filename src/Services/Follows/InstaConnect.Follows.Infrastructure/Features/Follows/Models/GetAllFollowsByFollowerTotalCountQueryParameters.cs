namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowerTotalCountQueryParameters(
    string FollowerId,
    string FollowingName);
