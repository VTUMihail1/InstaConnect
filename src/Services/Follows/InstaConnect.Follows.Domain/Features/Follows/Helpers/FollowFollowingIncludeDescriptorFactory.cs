using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowingIncludeDescriptorFactory : IFollowFollowingIncludeDescriptorFactory
{
    public FollowsIncludeDescriptor CreateFollower()
    {
        return new(FollowsDestinationType.FollowFollowings, FollowsIncludeType.Followers);
    }

    public FollowsIncludeDescriptor CreateFollowing()
    {
        return new(FollowsDestinationType.FollowFollowings, FollowsIncludeType.Followings);
    }
}
