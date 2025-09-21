using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
internal interface IChatMessageCollectionFactory
{
    ChatMessageCollection Create(
        ICollection<ChatMessage> chatMessages,
        int totalCount,
        ChatMessagePaginationQuery pagination);
}
