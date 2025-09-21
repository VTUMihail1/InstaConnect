using InstaConnect.Users.Application.Features.Users.Models;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetAll;

public record GetAllUsersApiResponse(
    ICollection<UserApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
