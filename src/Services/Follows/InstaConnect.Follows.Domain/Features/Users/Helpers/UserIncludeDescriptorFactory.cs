using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
    public FollowsIncludeDescriptor CreateFollowFollowers()
    {
        return new(FollowsDestinationType.Users, FollowsIncludeType.FollowFollowers);
    }

    public FollowsIncludeDescriptor CreateFollowFollowings()
    {
        return new(FollowsDestinationType.Users, FollowsIncludeType.Followings);
    }
}
