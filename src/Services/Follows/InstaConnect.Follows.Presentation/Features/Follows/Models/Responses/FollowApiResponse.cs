namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowApiResponse(
    UserApiResponse Follower,
    UserApiResponse Following,
    DateTimeOffset CreatedAtUtc);
