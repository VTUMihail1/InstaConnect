namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers;

internal class ChatCollectionFactory : IChatCollectionFactory
{
    private readonly IPaginator _paginator;

    public ChatCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public ChatCollection Create(ICollection<Chat> chats, int totalCount, CommonPaginationQuery pagination)
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
