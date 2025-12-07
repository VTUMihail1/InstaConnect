using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQueryRequest(
    string FirstName,
    string LastName,
    string Name,
    CommonSortOrder SortOrder,
    UserSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllUsersQueryResponse>;
