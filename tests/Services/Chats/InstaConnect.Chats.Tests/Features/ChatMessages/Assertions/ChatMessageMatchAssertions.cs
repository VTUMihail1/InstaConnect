using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Assertions;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(ChatMessage u)
	{
		public void ShouldSatisfy(ChatMessage chatMessage)
		{
			u.ShouldSatisfy(u => u.Matches(chatMessage));
		}
	}
}
