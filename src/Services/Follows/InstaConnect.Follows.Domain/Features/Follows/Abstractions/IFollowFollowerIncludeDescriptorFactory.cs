using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFollowerIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollower();
    FollowsIncludeDescriptor CreateFollowing();
}
