using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

public record FollowId(UserId FollowerId, UserId FollowingId) : IEntityId;
