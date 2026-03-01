using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowQueryResponse(
    string FollowerId,
    string FollowingId,
    UserQueryResponse? Follower,
    UserQueryResponse? Following,
    bool IsFollowedByCurrentUser,
    DateTimeOffset CreatedAtUtc);
