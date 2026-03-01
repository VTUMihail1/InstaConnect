using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowerIncludeDescriptorFactory : IFollowFollowerIncludeDescriptorFactory
{
    public FollowsIncludeDescriptor CreateFollower()
    {
        return new(FollowsDestinationType.FollowFollowers, FollowsIncludeType.Followers);
    }

    public FollowsIncludeDescriptor CreateFollowing()
    {
        return new(FollowsDestinationType.FollowFollowers, FollowsIncludeType.Followings);
    }
}
