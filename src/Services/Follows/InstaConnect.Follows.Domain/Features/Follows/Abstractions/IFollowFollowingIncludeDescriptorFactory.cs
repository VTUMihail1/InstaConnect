using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFollowingIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollower();
	public FollowsIncludeDescriptor CreateFollowing();
}
