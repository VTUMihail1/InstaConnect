using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFollowingIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollower();
    FollowsIncludeDescriptor CreateFollowing();
}