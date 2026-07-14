using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageNotificationAssertions
{
	extension(ChatMessageAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(command, chatMessage));
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public void ShouldSatisfy(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(command, chatMessage));
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public void ShouldSatisfy(
			DeleteChatMessageCommand command,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(command, chatMessage));
		}
	}
}
