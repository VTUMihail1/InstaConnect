using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageQueryService chatMessageService)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(GetAllChatMessagesQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.GetAllAsync(request.IsGetAllChatMessagesQuery(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(GetChatMessageByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.GetByIdAsync(request.IsGetChatMessageByIdQuery(), cancellationToken);
		}
	}

	extension(IChatMessageCommandService chatMessageService)
	{
		public async Task ShouldHaveReceivedOneAddAsync(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.AddAsync(request.IsAddChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.UpdateAsync(request.IsUpdateChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(DeleteChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.DeleteAsync(request.IsDeleteChatMessageCommand(), cancellationToken);
		}
	}
}
