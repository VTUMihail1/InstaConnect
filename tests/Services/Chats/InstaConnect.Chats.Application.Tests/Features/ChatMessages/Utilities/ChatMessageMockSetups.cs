namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IChatMessageQueryService commentService)
	{
		public void SetupGetAllQuery(
		GetAllChatMessagesQueryRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages,
		CancellationToken cancellationToken)
		{
			commentService
				.GetAllAsync(ChatMessageMatcher.IsGetAllChatMessagesQuery(request), cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToResponse(chat, request));
		}

		public void SetupGetByIdQuery(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(ChatMessageMatcher.IsGetChatMessageByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}
	}

	extension(IChatMessageCommandService commentService)
	{
		public void SetupAddCommand(
		AddChatMessageCommandRequest request,
		ChatMessage chatMessage,
		CancellationToken cancellationToken)
		{
			commentService
				.AddAsync(ChatMessageMatcher.IsAddChatMessageCommand(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}

		public void SetupUpdateCommand(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(ChatMessageMatcher.IsUpdateChatMessageCommand(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}
	}
}
