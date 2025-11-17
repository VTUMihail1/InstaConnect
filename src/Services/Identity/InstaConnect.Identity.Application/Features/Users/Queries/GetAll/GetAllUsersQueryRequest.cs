namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryRequest(
    UserFilterQueryRequest Filter,
    UserSortingQueryRequest Sorting,
    UserPaginationQueryRequest Pagination)
    : IQueryRequest<GetAllUsersQueryResponse>;
