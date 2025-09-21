using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers;

internal class ChatCollectionFactory : IChatCollectionFactory
{
    private readonly IPaginator _paginator;

    public ChatCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public ChatCollection Create(ICollection<Chat> chats, int totalCount, ChatPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new ChatCollection(
            chats,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
