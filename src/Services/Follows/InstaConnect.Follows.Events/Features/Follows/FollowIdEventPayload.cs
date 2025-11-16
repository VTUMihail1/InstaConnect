using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Follows.Events.Features.Follows;

public record FollowIdEventPayload(UserIdEventPayload FollowerId, UserIdEventPayload FollowingId);
