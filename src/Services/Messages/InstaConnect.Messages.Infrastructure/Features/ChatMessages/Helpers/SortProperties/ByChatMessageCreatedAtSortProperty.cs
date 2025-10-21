using System.Linq.Expressions;

using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByChatMessageCreatedAtSortProperty : IChatMessageSortProperty
{
    public ChatMessageSortProperty SortProperty => ChatMessageSortProperty.ByCreatedAt;

    public Expression<Func<ChatMessage, object>> Property => p => p.CreatedAt;
}
