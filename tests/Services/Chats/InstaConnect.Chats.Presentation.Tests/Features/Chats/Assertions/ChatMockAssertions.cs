using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Application.Features.Requests.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldReceiveOneSendAsync(
		GetAllChatsApiRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetAllChatsQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			GetChatByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsGetChatByIdQueryRequest(), cancellationToken);
		}

		public async Task ShouldReceiveOneSendAsync(
			AddChatApiRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldHaveReceivedOne().SendAsync(request.IsAddChatCommandRequest(), cancellationToken);
		}
	}
}
