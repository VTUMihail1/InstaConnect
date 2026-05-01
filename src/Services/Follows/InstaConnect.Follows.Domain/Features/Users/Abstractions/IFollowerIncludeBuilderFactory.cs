using InstaConnect.Follows.Domain.Features.Users.Helpers;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IFollowerIncludeBuilderFactory
{
	public FollowerIncludeBuilder Create();
}
