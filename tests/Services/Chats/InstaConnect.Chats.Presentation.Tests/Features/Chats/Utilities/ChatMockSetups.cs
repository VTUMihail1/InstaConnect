using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync(
		GetAllChatsApiRequest request,
		User participantOne,
		ICollection<Chat> chats,
		CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatPresentationMatcher.IsGetAllChatsQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(chats.ToResponse(request, participantOne));
		}

		public void SetupSendAsync(
			GetChatByIdApiRequest request,
			Chat chat,
			CancellationToken cancellationToken)
		{
			sender
				.SendAsync(ChatPresentationMatcher.IsGetChatByIdQueryRequest(request), cancellationToken)
				.ReturnsTaskResponse(chat.ToResponse(request));
		}

		public void SetupSendAsync(
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
