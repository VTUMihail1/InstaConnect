using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryRequest(
    string FirstName,
    string LastName,
    string Name,
    string CurrentId,
    CommonSortOrder SortOrder,
    UserSortProperty SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllUsersQueryResponse>, ISortableQueryRequest<UserSortProperty>, IPaginatableQueryRequest;
