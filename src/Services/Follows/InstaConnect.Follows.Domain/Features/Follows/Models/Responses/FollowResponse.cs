using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

public record FollowResponse(
    FollowId Id,
    UserResponse? Follower,
    UserResponse? Following,
    bool IsFollowedByCurrentUser,
    DateTimeOffset CreatedAtUtc) : IEntityResponse;
