using InstaConnect.Users.Domain.Features.Users.Models;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryRequest(
    UserQueryFilter Filter,
    UserQuerySorting Sorting,
    UserQueryPagination Pagination)
    : IQueryRequest<GetAllUsersQueryResponse>;
