using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollower();
    FollowsIncludeDescriptor CreateFollowing();
}