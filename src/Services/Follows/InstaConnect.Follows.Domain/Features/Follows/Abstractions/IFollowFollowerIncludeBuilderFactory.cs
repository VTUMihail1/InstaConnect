using InstaConnect.Follows.Domain.Features.Follows.Helpers;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFollowerIncludeBuilderFactory
{
	public FollowFollowerIncludeBuilder Create();
}
