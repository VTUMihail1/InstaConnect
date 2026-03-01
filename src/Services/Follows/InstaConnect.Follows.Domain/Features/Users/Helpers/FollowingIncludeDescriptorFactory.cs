using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowingIncludeDescriptorFactory : IFollowingIncludeDescriptorFactory
{
    public FollowsIncludeDescriptor CreateFollowFollowers()
    {
        return new(FollowsDestinationType.Followings, FollowsIncludeType.FollowFollowers);
    }

    public FollowsIncludeDescriptor CreateFollowFollowings()
    {
        return new(FollowsDestinationType.Followings, FollowsIncludeType.Followings);
    }
}
