using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatMessagePresentationMatcher.IsGetAllChatMessagesQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatMessagePresentationMatcher.IsGetChatMessageByIdQueryRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatMessagePresentationMatcher.IsAddChatMessageCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatMessagePresentationMatcher.IsUpdateChatMessageCommandRequest(request), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(ChatMessagePresentationMatcher.IsDeleteChatMessageCommandRequest(request), cancellationToken);
		}
	}
}
