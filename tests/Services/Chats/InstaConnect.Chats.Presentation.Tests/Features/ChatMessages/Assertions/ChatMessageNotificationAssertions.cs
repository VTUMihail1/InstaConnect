using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageNotificationAssertions
{
	extension(ChatMessageAddedNotificationRequest r)
	{
		public void ShouldSatisfy(
			AddChatMessageApiRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(
			AddChatMessageApiRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(request, chatMessage));
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public void ShouldSatisfy(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(request, chatMessage));
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public void ShouldSatisfy(
			DeleteChatMessageApiRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(
			DeleteChatMessageApiRequest request,
			ChatMessage chatMessage)
		{
			r.ShouldSatisfy(f => f.MatchesInverted(request, chatMessage));
		}
	}
}
