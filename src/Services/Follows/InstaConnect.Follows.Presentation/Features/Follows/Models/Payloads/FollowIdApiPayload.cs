namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Payloads;
public record FollowIdApiPayload(UserIdApiPayload FollowerId, UserIdApiPayload FollowingId);
