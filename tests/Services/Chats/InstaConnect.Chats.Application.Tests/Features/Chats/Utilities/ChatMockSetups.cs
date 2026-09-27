namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IChatQueryService service)
	{
		public void SetupGetAllAsync(
		GetAllChatsQueryRequest request,
		User participantOne,
		ICollection<Chat> chats,
		CancellationToken cancellationToken)
		{
			service
				.GetAllAsync(request.IsGetAllChatsQuery(), cancellationToken)
				.ReturnsTaskResponse(chats.ToResponse(request, participantOne));
		}

		public void SetupGetByIdAsync(
			GetChatByIdQueryRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			service
				.GetByIdAsync(request.IsGetChatByIdQuery(), cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(request));
		}
	}

	extension(IChatCommandService service)
	{
		public void SetupAddAsync(
		AddChatCommandRequest request,
		Chat chat,
		CancellationToken cancellationToken)
		{
			service
				.AddAsync(request.IsAddChatCommand(), cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(request));
		}
	}
}
