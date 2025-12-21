using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers;

internal class ChatMessageCollectionFactory : IChatMessageCollectionFactory
{
    private readonly IPaginator _paginator;

    public ChatMessageCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public ChatMessageCollection Create(ICollection<ChatMessage> chatMessages, int totalCount, CommonPaginationQuery pagination)
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
