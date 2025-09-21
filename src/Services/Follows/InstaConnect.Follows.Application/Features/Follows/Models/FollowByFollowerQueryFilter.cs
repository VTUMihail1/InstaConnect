namespace InstaConnect.Follows.Domain.Features.Follows.Models;

public record FollowByFollowerQueryFilter(
    string FollowerId,
    string FollowingName);
