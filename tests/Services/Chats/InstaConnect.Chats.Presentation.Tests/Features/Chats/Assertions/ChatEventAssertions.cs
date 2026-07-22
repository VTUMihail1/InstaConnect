using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatEventAssertions
{
	extension(ChatAddedEventRequest r)
	{
		public bool ShouldSatisfy(AddChatApiRequest request, Chat entity)
		{
			return r.Matches(request, entity);
		}
	}
}
