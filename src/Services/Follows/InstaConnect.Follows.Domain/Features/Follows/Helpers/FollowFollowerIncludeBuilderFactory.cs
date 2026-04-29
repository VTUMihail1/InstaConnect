namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowerIncludeBuilderFactory : IFollowFollowerIncludeBuilderFactory
{
	private readonly IFollowFollowerIncludeDescriptorFactory _descriptorFactory;

	public FollowFollowerIncludeBuilderFactory(IFollowFollowerIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public FollowFollowerIncludeBuilder Create()
	{
		return new FollowFollowerIncludeBuilder([], _descriptorFactory);
	}
}
