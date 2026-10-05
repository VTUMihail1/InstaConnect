using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IChatQueryService chatService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
		GetAllChatsQueryRequest request,
		CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOne().GetAllAsync(request.IsGetAllChatsQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOne().GetByIdAsync(request.IsGetChatByIdQuery(), cancellationToken);
		}
	}

	extension(IChatCommandService chatService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
		AddChatCommandRequest request,
		CancellationToken cancellationToken)
		{
			await chatService.ShouldHaveReceivedOne().AddAsync(request.IsAddChatCommand(), cancellationToken);
		}
	}
}
