namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowApiResponse(FollowUserApiResponse Follower, FollowUserApiResponse Following);
