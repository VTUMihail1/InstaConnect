namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowingIncludeBuilderFactory : IFollowFollowingIncludeBuilderFactory
{
	private readonly IFollowFollowingIncludeDescriptorFactory _descriptorFactory;

	public FollowFollowingIncludeBuilderFactory(IFollowFollowingIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public FollowFollowingIncludeBuilder Create()
	{
		return new FollowFollowingIncludeBuilder([], _descriptorFactory);
	}
}
