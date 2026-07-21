namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMatcher
{
	public static ChatInclude IsChatInclude(AddChatMessageCommand command, ChatInclude include)
	{
		return Matcher.Is<ChatInclude>(p => p.Matches(command, include));
	}

	public static ChatMessageInclude IsChatMessageInclude(UpdateChatMessageCommand command, ChatMessageInclude include)
	{
		return Matcher.Is<ChatMessageInclude>(p => p.Matches(command, include));
	}

	public static ChatMessageInclude IsChatMessageInclude(DeleteChatMessageCommand command, ChatMessageInclude include)
	{
		return Matcher.Is<ChatMessageInclude>(p => p.Matches(command, include));
	}

	public static ChatMessage IsChatMessage(AddChatMessageCommand command)
	{
		return Matcher.Is<ChatMessage>(p => p.Matches(command));
	}

	public static ChatMessage IsChatMessage(UpdateChatMessageCommand command)
	{
		return Matcher.Is<ChatMessage>(p => p.Matches(command));
	}

	public static ChatMessage IsChatMessage(DeleteChatMessageCommand command)
	{
		return Matcher.Is<ChatMessage>(p => p.Matches(command));
	}

	public static ChatMessageAddedNotificationRequest IsChatMessageAddedNotificationRequest(AddChatMessageCommand command, ChatMessage chatMessage)
	{
		return Matcher.Is<ChatMessageAddedNotificationRequest>(p => p.Matches(command, chatMessage));
	}

	public static ChatMessageUpdatedNotificationRequest IsChatMessageUpdatedNotificationRequest(UpdateChatMessageCommand command, ChatMessage chatMessage)
	{
		return Matcher.Is<ChatMessageUpdatedNotificationRequest>(p => p.Matches(command, chatMessage));
	}

	public static ChatMessageDeletedNotificationRequest IsChatMessageDeletedNotificationRequest(DeleteChatMessageCommand command, ChatMessage chatMessage)
	{
		return Matcher.Is<ChatMessageDeletedNotificationRequest>(p => p.Matches(command, chatMessage));
	}
}
