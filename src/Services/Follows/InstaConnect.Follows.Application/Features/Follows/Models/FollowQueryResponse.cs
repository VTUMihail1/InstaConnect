namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowQueryResponse(FollowUserQueryResponse Follower, FollowUserQueryResponse Following);
