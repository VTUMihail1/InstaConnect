namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowerQueryFilter(
    string FollowerId,
    string FollowingName);
