using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFollowingIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollower();
    FollowsIncludeDescriptor CreateFollowing();
}
