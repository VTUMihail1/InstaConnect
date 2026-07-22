using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Events.Features.Chats;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatEventAssertions
{
	extension(ChatAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddChatCommandRequest request, Chat entity)
		{
			return r.Matches(request, entity);
		}
	}
}
