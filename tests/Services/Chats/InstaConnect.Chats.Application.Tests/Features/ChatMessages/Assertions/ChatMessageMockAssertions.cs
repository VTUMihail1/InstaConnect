using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IChatMessageQueryService chatMessageService)
	{
		public async Task ShouldReceiveOneGetAllAsync(GetAllChatMessagesQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.GetAllAsync(ChatMessageApplicationMatcher.IsGetAllChatMessagesQuery(request), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(GetChatMessageByIdQueryRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.GetByIdAsync(ChatMessageApplicationMatcher.IsGetChatMessageByIdQuery(request), cancellationToken);
		}
	}

	extension(IChatMessageCommandService chatMessageService)
	{
		public async Task ShouldReceiveOneAddAsync(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.AddAsync(ChatMessageApplicationMatcher.IsAddChatMessageCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.UpdateAsync(ChatMessageApplicationMatcher.IsUpdateChatMessageCommand(request), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(DeleteChatMessageCommandRequest request, CancellationToken cancellationToken)
		{
			await chatMessageService.ShouldHaveReceivedOne()
				.DeleteAsync(ChatMessageApplicationMatcher.IsDeleteChatMessageCommand(request), cancellationToken);
		}
	}
}
