namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers;

internal class UserCollectionFactory : IUserCollectionFactory
{
    private readonly IPaginator _paginator;

    public UserCollectionFactory(IPaginator paginator)
    {
        _paginator = paginator;
    }

    public UserCollection Create(ICollection<User> users, int totalCount, UserPaginationQuery pagination)
    {
        var hasNextPage = _paginator.HasNextPage(pagination.Page, pagination.PageSize, totalCount);
        var hasPreviousPage = _paginator.HasPreviousPage(pagination.Page);

        return new UserCollection(
            users,
            pagination.Page,
            pagination.PageSize,
            totalCount,
            hasNextPage,
            hasPreviousPage);
    }
}
