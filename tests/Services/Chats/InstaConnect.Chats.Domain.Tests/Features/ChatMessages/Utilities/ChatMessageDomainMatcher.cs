namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageDomainMatcher
{
	extension(AddChatMessageCommand command)
	{
		public ChatInclude IsChatInclude(ChatInclude include)
		{
			return Matcher.Is<ChatInclude>(p => p.Matches(command, include));
		}

		public ChatMessage IsChatMessage()
		{
			return Matcher.Is<ChatMessage>(p => p.Matches(command));
		}

		public ChatMessageAddedNotificationRequest IsChatMessageAddedNotificationRequest(ChatMessage chatMessage)
		{
			return Matcher.Is<ChatMessageAddedNotificationRequest>(p => p.Matches(command, chatMessage));
		}
	}

	extension(UpdateChatMessageCommand command)
	{
		public ChatMessageInclude IsChatMessageInclude(ChatMessageInclude include)
		{
			return Matcher.Is<ChatMessageInclude>(p => p.Matches(command, include));
		}

		public ChatMessage IsChatMessage()
		{
			return Matcher.Is<ChatMessage>(p => p.Matches(command));
		}

		public ChatMessageUpdatedNotificationRequest IsChatMessageUpdatedNotificationRequest(ChatMessage chatMessage)
		{
			return Matcher.Is<ChatMessageUpdatedNotificationRequest>(p => p.Matches(command, chatMessage));
		}
	}

	extension(DeleteChatMessageCommand command)
	{
		public ChatMessageInclude IsChatMessageInclude(ChatMessageInclude include)
		{
			return Matcher.Is<ChatMessageInclude>(p => p.Matches(command, include));
		}

		public ChatMessage IsChatMessage()
		{
			return Matcher.Is<ChatMessage>(p => p.Matches(command));
		}

		public ChatMessageDeletedNotificationRequest IsChatMessageDeletedNotificationRequest(ChatMessage chatMessage)
		{
			return Matcher.Is<ChatMessageDeletedNotificationRequest>(p => p.Matches(command, chatMessage));
		}
	}
}
