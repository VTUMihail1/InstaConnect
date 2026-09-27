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
				.GetAllAsync(request.IsGetAllChatMessagesQuery(), cancellationToken)
				.ReturnsTaskResponse(chatMessages.ToResponse(request, chat));
		}

		public void SetupGetByIdAsync(
			GetChatMessageByIdQueryRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService
				.GetByIdAsync(request.IsGetChatMessageByIdQuery(), cancellationToken)
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
				.AddAsync(request.IsAddChatMessageCommand(), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}

		public void SetupUpdateAsync(
			UpdateChatMessageCommandRequest request,
			ChatMessage chatMessage,
			CancellationToken cancellationToken)
		{
			commentService
				.UpdateAsync(request.IsUpdateChatMessageCommand(), cancellationToken)
				.ReturnsTaskResponse(chatMessage.ToResponse(request));
		}
	}
}
