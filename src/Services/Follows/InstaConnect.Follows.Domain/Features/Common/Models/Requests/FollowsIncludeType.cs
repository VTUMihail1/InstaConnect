namespace InstaConnect.Follows.Domain.Features.Common.Models.Requests;

public enum FollowsIncludeType
{
    None,
    Follower,
    Following,
    FollowFollower,
    FollowFollowing
}
