using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Helpers;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowMockFactory
{
	public static IFollowIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new FollowIncludeBuilderFactory(new FollowIncludeDescriptorFactory());
	}
}
