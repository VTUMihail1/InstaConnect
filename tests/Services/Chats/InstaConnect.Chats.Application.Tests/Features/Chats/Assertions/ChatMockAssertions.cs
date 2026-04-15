using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatMockAssertions
{
    extension(IChatQueryService chatService)
    {
        public async Task ShouldReceiveOneGetAllAsync(
        GetAllChatsQueryRequest request,
        CancellationToken cancellationToken)
        {
            await chatService.ShouldHaveReceivedOne().GetAllAsync(ChatMatcher.IsGetAllChatsQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(
            GetChatByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await chatService.ShouldHaveReceivedOne().GetByIdAsync(ChatMatcher.IsGetChatByIdQuery(request), cancellationToken);
        }
    }

    extension(IChatCommandService chatService)
    {
        public async Task ShouldReceiveOneAddAsync(
        AddChatCommandRequest request,
        CancellationToken cancellationToken)
        {
            await chatService.ShouldHaveReceivedOne().AddAsync(ChatMatcher.IsAddChatCommand(request), cancellationToken);
        }
    }
}
