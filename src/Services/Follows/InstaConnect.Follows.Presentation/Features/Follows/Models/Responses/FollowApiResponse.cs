namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowApiResponse(FollowUserApiResponse Follower, FollowUserApiResponse Following);
