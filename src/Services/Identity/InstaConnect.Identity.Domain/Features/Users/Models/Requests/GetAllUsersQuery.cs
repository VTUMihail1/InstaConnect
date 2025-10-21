using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllUsersQuery(
    UserFilterQuery Filter,
    UserSortingQuery Sorting,
    UserPaginationQuery Pagination)
{
    public UserIncludeQuery? Include { get; private set; }

    public GetAllUsersQuery AddInclude(UserIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
