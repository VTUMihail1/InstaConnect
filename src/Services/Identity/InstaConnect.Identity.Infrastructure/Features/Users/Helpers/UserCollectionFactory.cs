using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Users.Infrastructure.Features.Users.Helpers;

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
