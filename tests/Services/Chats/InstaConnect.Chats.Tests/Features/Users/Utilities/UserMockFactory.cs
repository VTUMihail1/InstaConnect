using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Domain.Features.Users.Helpers;

namespace InstaConnect.Chats.Tests.Features.Users.Utilities;

public static class UserMockFactory
{
	public static IUserIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new UserIncludeBuilderFactory(new UserIncludeDescriptorFactory());
	}
}
