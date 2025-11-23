namespace InstaConnect.Follows.Application.Features.Follows.Models;
public record FollowIdPayload(UserIdPayload FollowerId, UserIdPayload FollowingId);
