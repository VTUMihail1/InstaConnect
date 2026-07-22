using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Events.Features.Chats;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatEventAssertions
{
	extension(ChatAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddChatCommand command, Chat entity)
		{
			return r.Matches(command, entity);
		}
	}
}
