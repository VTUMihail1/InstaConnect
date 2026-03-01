using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowIncludeDescriptorFactory : IFollowIncludeDescriptorFactory
{
    public FollowsIncludeDescriptor CreateFollower()
    {
        return new(FollowsDestinationType.Follows, FollowsIncludeType.Followers);
    }

    public FollowsIncludeDescriptor CreateFollowing()
    {
        return new(FollowsDestinationType.Follows, FollowsIncludeType.Followings);
    }
}
