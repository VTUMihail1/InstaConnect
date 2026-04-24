using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IFollowingIncludeDescriptorFactory
{
    FollowsIncludeDescriptor CreateFollowFollowers();
    FollowsIncludeDescriptor CreateFollowFollowings();
}