using InstaConnect.Chats.Events.Features.Chats;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatMatcher
{
	public static Chat IsChat(AddChatCommand command)
	{
		return Matcher.Is<Chat>(p => p.Matches(command));
	}

	public static ChatAddedEventRequest IsChatAddedEventRequest(AddChatCommand command, Chat chat)
	{
		return Matcher.Is<ChatAddedEventRequest>(p => p.Matches(command, chat));
	}
}
