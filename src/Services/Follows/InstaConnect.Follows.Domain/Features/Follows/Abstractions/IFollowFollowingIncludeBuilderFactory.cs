using InstaConnect.Follows.Domain.Features.Follows.Helpers;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFollowingIncludeBuilderFactory
{
	public FollowFollowingIncludeBuilder Create();
}
