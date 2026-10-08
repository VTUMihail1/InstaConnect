using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Helpers;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public static class UserMockFactory
{
	public static IUserIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new UserIncludeBuilderFactory(new UserIncludeDescriptorFactory());
	}
}
