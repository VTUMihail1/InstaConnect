using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllChatMessagesApiRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatMessagePresentationMatcher.IsGetAllChatMessagesQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToResponse(request, chat));
		}

		public void SetupSendAsync(
			GetChatMessageByIdApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatMessagePresentationMatcher.IsGetChatMessageByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}

		public void SetupSendAsync(
			AddChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatMessagePresentationMatcher.IsAddChatMessageCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}

		public void SetupSendAsync(
			UpdateChatMessageApiRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatMessagePresentationMatcher.IsUpdateChatMessageCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}
	}
}
