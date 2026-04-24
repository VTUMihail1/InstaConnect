using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

public record FollowId(UserId FollowerId, UserId FollowingId) : IEntityId;
