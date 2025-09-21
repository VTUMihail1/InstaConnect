namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllUsersQuery(
    UserFilterQuery Filter,
    UserSortingQuery Sorting,
    UserPaginationQuery Pagination);
