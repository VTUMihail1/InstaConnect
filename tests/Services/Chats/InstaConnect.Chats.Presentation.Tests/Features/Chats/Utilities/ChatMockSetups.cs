using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupGetAllQueryRequest(
		GetAllChatsApiRequest request,
		User participantOne,
		ICollection<Chat> chats,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatPresentationMatcher.IsGetAllChatsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(chats.ToResponse(request, participantOne));
		}

		public void SetupGetByIdQueryRequest(
			GetChatByIdApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatPresentationMatcher.IsGetChatByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(request));
		}

		public void SetupAddCommandRequest(
			AddChatApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatPresentationMatcher.IsAddChatCommandRequest(request), cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(request));
		}
	}
}
