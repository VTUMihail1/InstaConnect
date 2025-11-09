using System.Linq.Expressions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageSortProperty
{
    public ChatMessageSortProperty SortProperty { get; }

    public Expression<Func<ChatMessage, object>> Property { get; }
}
