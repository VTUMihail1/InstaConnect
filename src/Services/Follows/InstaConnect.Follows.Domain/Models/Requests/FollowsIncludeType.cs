namespace InstaConnect.Follows.Domain.Models.Requests;

public enum FollowsIncludeType
{
    None,
    Follower,
    Following,
    FollowFollower,
    FollowFollowing
}
