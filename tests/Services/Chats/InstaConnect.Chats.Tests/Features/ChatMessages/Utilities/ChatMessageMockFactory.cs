using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockFactory
{
	public static IChatMessageIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new ChatMessageIncludeBuilderFactory(new ChatMessageIncludeDescriptorFactory());
	}
}
