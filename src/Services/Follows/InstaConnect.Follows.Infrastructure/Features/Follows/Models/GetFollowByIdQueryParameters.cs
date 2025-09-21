namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models;

public record GetFollowByIdQueryParameters(
    string FollowerId,
    string FollowingId);
