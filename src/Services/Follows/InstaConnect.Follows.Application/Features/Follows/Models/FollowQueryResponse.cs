namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowQueryResponse(
    UserQueryResponse Follower,
    UserQueryResponse Following,
    DateTimeOffset CreatedAtUtc);
