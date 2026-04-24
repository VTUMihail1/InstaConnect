using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMockSetups
{
    extension(IApplicationSender sender)
    {
        public void SetupGetAllQueryRequest(
        GetAllChatMessagesApiRequest request,
        Chat chat,
        ICollection<ChatMessage> chatMessages,
        CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMessageMatcher.IsGetAllChatMessagesQueryRequest(request), cancellationToken)
                .ReturnsResponse(chatMessages.ToResponse(chat, request));
        }

        public void SetupGetByIdQueryRequest(
            GetChatMessageByIdApiRequest request,
            ChatMessage chatMessage,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMessageMatcher.IsGetChatMessageByIdQueryRequest(request), cancellationToken)
                .ReturnsResponse(chatMessage.ToResponse(request));
        }

        public void SetupAddCommandRequest(
            AddChatMessageApiRequest request,
            ChatMessage chatMessage,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMessageMatcher.IsAddChatMessageCommandRequest(request), cancellationToken)
                .ReturnsResponse(chatMessage.ToResponse(request));
        }

        public void SetupUpdateCommandRequest(
            UpdateChatMessageApiRequest request,
            ChatMessage chatMessage,
            CancellationToken cancellationToken)
        {
            sender
                .SendAsync(ChatMessageMatcher.IsUpdateChatMessageCommandRequest(request), cancellationToken)
                .ReturnsResponse(chatMessage.ToResponse(request));
        }
    }
}
