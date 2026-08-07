using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Assertions;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(Chat u)
	{
		public void ShouldSatisfy(Chat chat)
		{
			u.ShouldSatisfy(u => u.Matches(chat));
		}
	}
}
