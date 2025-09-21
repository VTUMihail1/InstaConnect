namespace InstaConnect.Follows.Domain.Features.Follows.Models;

public record FollowByFollowingQueryFilter(
    string FollowingId,
    string FollowerName);
