using System.Linq.Expressions;

using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByChatByParticipantCreatedAtSortProperty : IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty => ChatByParticipantSortProperty.ByCreatedAt;

    public Expression<Func<Chat, object>> Property => p => p.CreatedAt;
}
