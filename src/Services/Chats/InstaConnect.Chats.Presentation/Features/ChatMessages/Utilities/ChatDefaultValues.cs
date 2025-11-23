using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Utilities;

public static class ChatMessageDefaultValues
{
    public const ChatMessageSortProperty SortProperty = ChatMessageSortProperty.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
