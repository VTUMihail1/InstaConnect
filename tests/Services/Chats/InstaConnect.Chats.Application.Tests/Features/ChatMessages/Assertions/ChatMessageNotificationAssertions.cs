using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageNotificationAssertions
{
	extension(ChatMessageAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public void ShouldSatisfy(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public void ShouldSatisfy(
			DeleteChatMessageCommandRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}
	}
}
