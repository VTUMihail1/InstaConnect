namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers;

internal class FollowCollectionFactory : IFollowCollectionFactory
{
    private readonly IPaginator _paginator;

    public FollowCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public FollowCollection Create(ICollection<Follow> follows, int totalCount, FollowPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new FollowCollection(
            follows,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
