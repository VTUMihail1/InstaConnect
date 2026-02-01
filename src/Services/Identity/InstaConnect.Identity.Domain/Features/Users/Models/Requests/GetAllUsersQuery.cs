namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record GetAllUsersQuery(
    UserFilterQuery Filter,
    UserSortingQuery Sorting,
    UserPaginationQuery Pagination,
    CurrentUserQuery Current)
    : ISortableQuery<UserSortingQuery, UserSortProperty>, IPaginatableQuery<UserPaginationQuery>;
