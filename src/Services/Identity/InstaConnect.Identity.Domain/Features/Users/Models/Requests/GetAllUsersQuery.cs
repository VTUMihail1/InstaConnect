namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

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
