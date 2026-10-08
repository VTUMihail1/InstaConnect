using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Helpers;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatMockFactory
{
	public static IChatIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new ChatIncludeBuilderFactory(new ChatIncludeDescriptorFactory());
	}
}
