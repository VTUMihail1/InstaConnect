namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
	extension(IChatMessageQueryService commentService)
	{
		public void SetupGetAllAsync(
		GetAllChatMessagesQueryRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages,
		CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.GetAllAsync(ChatMessageApplicationMatcher.IsGetAllChatMessagesQuery(request), cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToResponse(request, chat));
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.GetByIdAsync(ChatMessageApplicationMatcher.IsGetChatMessageByIdQuery(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}
	}

	extension(IChatMessageCommandService commentService)
	{
		public void SetupAddAsync(
		AddChatMessageCommandRequest request,
		ChatMessage chatMessage,
		CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.AddAsync(ChatMessageApplicationMatcher.IsAddChatMessageCommand(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService
				.ClearCalls()
				.UpdateAsync(ChatMessageApplicationMatcher.IsUpdateChatMessageCommand(request), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}
	}
}
