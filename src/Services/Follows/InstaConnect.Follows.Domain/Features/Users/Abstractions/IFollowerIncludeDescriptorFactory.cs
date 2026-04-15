using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IFollowerIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollowFollowers();
    FollowsIncludeDescriptor CreateFollowFollowings();
}