namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowingQueryFilter(
    string FollowingId,
    string FollowerName);
