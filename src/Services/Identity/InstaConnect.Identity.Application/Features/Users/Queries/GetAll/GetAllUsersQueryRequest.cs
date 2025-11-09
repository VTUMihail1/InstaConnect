namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryRequest(
    UserQueryFilter Filter,
    UserQuerySorting Sorting,
    UserQueryPagination Pagination)
    : IQueryRequest<GetAllUsersQueryResponse>;
