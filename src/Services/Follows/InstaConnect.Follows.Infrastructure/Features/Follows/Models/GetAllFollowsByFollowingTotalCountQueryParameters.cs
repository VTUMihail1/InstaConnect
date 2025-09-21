namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetAllFollowsByFollowingTotalCountQueryParameters(
    string FollowingId,
    string FollowerName);
