using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMockSetups
{
    extension(IApplicationSender sender)
    {
        public void SetupGetAllQueryRequest(
        GetAllChatsApiRequest request,
        User participantOne,
        ICollection<Chat> chats,
        CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMatcher.IsGetAllChatsQueryRequest(request), cancellationToken)
                .ReturnsResponse(chats.ToResponse(participantOne, request));
        }

        public void SetupGetByIdQueryRequest(
            GetChatByIdApiRequest request,
            Chat chat,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMatcher.IsGetChatByIdQueryRequest(request), cancellationToken)
                .ReturnsResponse(chat.ToResponse(request));
        }

        public void SetupAddCommandRequest(
            AddChatApiRequest request,
            Chat chat,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMatcher.IsAddChatCommandRequest(request), cancellationToken)
                .ReturnsResponse(chat.ToResponse(request));
        }
    }
}
