using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllChatMessagesApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllChatMessagesQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetChatMessageByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetChatMessageByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddChatMessageCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			UpdateChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsUpdateChatMessageCommandRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			DeleteChatMessageApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsDeleteChatMessageCommandRequest(), cancellationToken);
		}
	}
}
