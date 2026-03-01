namespace InstaConnect.Follows.Domain.Models.Requests;

public enum FollowsIncludeType
{
    None,
    Followers,
    Followings,
    FollowFollowers,
    FollowFollowings
}
