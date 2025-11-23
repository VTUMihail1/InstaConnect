namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowQueryResponse(
    FollowIdPayload Id,
    UserQueryResponse Follower,
    UserQueryResponse Following,
    DateTimeOffset CreatedAtUtc);
