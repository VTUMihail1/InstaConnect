using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IFollowingIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers();
	public FollowsIncludeDescriptor CreateFollowFollowings();
}
