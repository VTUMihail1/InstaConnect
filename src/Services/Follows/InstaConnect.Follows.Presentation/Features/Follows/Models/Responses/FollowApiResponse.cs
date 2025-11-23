namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowApiResponse(
    FollowIdApiPayload Id,
    UserApiResponse Follower,
    UserApiResponse Following,
    DateTimeOffset CreatedAtUtc);
