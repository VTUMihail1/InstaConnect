using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowerIncludeDescriptorFactory : IFollowerIncludeDescriptorFactory
{
    public FollowsIncludeDescriptor CreateFollowFollowers()
    {
        return new(FollowsDestinationType.Followers, FollowsIncludeType.FollowFollowers);
    }

    public FollowsIncludeDescriptor CreateFollowFollowings()
    {
        return new(FollowsDestinationType.Followers, FollowsIncludeType.Followings);
    }
}
