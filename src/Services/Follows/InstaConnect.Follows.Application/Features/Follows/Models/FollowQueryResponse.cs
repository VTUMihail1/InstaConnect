namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowQueryResponse(
    string FollowerId,
    string FollowingId,
    UserQueryResponse? Follower,
    UserQueryResponse? Following,
    bool IsFollowedByCurrentUser,
    DateTimeOffset CreatedAtUtc);
