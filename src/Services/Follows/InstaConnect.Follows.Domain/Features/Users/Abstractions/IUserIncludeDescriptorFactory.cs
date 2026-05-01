using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers();

	public FollowsIncludeDescriptor CreateFollowFollowings();
}
