using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMockAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
        GetAllChatMessagesApiRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMessageMatcher.IsGetAllChatMessagesQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            GetChatMessageByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMessageMatcher.IsGetChatMessageByIdQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            AddChatMessageApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMessageMatcher.IsAddChatMessageCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            UpdateChatMessageApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMessageMatcher.IsUpdateChatMessageCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            DeleteChatMessageApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(ChatMessageMatcher.IsDeleteChatMessageCommandRequest(request), cancellationToken);
        }
    }
}
