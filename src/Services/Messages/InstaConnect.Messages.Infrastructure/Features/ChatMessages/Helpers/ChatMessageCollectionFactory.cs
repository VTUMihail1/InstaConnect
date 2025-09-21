using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Helpers;

internal class ChatMessageCollectionFactory : IChatMessageCollectionFactory
{
    private readonly IPaginator _paginator;

    public ChatMessageCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public ChatMessageCollection Create(ICollection<ChatMessage> chatMessages, int totalCount, ChatMessagePaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new ChatMessageCollection(
            chatMessages,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
