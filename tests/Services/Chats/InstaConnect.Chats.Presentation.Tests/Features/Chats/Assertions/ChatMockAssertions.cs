using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
        GetAllChatsApiRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMatcher.IsGetAllChatsQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            GetChatByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMatcher.IsGetChatByIdQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            AddChatApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMatcher.IsAddChatCommandRequest(request), cancellationToken);
        }
    }
}
