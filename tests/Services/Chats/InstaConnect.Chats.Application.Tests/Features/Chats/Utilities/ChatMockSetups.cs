namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
    extension(IChatQueryService service)
    {
        public void SetupGetAllQuery(
        GetAllChatsQueryRequest request,
        User participantOne,
        ICollection<Chat> chats,
        CancellationToken cancellationToken)
        {
            service
                .GetAllAsync(ChatMatcher.IsGetAllChatsQuery(request), cancellationToken)
                .ReturnsResponse(chats.ToResponse(participantOne, request));
        }

        public void SetupGetByIdQuery(
            GetChatByIdQueryRequest request,
            Chat chat,
            CancellationToken cancellationToken)
        {
            service
                .GetByIdAsync(ChatMatcher.IsGetChatByIdQuery(request), cancellationToken)
                .ReturnsResponse(chat.ToResponse(request));
        }
    }

    extension(IChatCommandService service)
    {
        public void SetupAddCommand(
        AddChatCommandRequest request,
        Chat chat,
        CancellationToken cancellationToken)
        {
            service
                .AddAsync(ChatMatcher.IsAddChatCommand(request), cancellationToken)
                .ReturnsResponse(chat.ToResponse(request));
        }
    }
}
