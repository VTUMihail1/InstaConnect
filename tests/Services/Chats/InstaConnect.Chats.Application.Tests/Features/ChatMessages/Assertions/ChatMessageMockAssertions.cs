using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageQueryService chatMessageService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllChatMessagesQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.GetAllAsync(request.IsGetAllChatMessagesQuery(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetChatMessageByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.GetByIdAsync(request.IsGetChatMessageByIdQuery(), cancellationToken);
		}
	}

	extension(IChatMessageCommandService chatMessageService)
	{
		public async Task ShouldReceiveOneAddAsync(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.AddAsync(request.IsAddChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.UpdateAsync(request.IsUpdateChatMessageCommand(), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeleteChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.DeleteAsync(request.IsDeleteChatMessageCommand(), cancellationToken);
		}
	}
}
