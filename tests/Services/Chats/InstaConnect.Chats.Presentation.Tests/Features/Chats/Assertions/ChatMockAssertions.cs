using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatPresentationMatcher.IsGetAllChatsQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatPresentationMatcher.IsGetChatByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatPresentationMatcher.IsAddChatCommandRequest(request), cancellationToken);
		}
	}
}
