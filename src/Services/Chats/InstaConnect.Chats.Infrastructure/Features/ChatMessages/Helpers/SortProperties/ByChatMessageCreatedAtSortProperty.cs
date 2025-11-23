using System.Linq.Expressions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.SortProperties;

public class ByChatMessageCreatedAtSortProperty : IChatMessageSortProperty
{
    public ChatMessageSortProperty SortProperty => ChatMessageSortProperty.ByCreatedAt;

    public Expression<Func<ChatMessage, object>> Property => p => p.CreatedAtUtc;
}
