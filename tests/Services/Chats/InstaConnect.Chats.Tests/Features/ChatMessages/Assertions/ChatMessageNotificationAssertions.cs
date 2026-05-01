
namespace InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageNotificationAssertions
{
	extension(ChatMessageAddedNotificationRequest request)
	{
		public void ShouldSatisfy(ChatMessage chatMessage)
		{
			request.ShouldSatisfy(f => f.Matches(chatMessage));
		}
	}

	extension(ChatMessageUpdatedNotificationRequest request)
	{
		public void ShouldSatisfy(ChatMessage chatMessage)
		{
			request.ShouldSatisfy(f => f.Matches(chatMessage));
		}
	}

	extension(ChatMessageDeletedNotificationRequest request)
	{
		public void ShouldSatisfy(ChatMessage chatMessage)
		{
			request.ShouldSatisfy(f => f.Matches(chatMessage));
		}
	}
}
